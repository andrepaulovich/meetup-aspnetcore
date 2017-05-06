using Meetup.Security.Middleware;
using Meetup.Security.Shared.BusinessObjects;
using Meetup.Security.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Meetup.Security.Shared.Auth
{
    public class TokenProviderMiddleware
    {
        public TokenProviderMiddleware(RequestDelegate next, IOptions<TokenProviderOptions> options)
        {
            Next = next;
            Options = options.Value;
        }

        private IGoalAuthenticationService AuthenticationService { get; set; }

        private RequestDelegate Next { get; set; }

        private TokenProviderOptions Options { get; set; }

        public Task Invoke(HttpContext context, IGoalAuthenticationService authenticationService)
        {
            AuthenticationService = authenticationService;

            // If the request path doesn't match, skip
            if (!context.Request.Path.Equals(Options.Path, StringComparison.Ordinal))
            {
                return Next?.Invoke(context);
            }

            return GenerateToken(context);
        }

        private async Task GenerateToken(HttpContext context)
        {
            // Request must be POST with Content-Type: application/x-www-form-urlencoded
            if (!context.Request.Method.Equals("POST") || !context.Request.HasFormContentType)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Bad request.");
                return;
            }

            var username = context.Request.Form["username"];
            var password = context.Request.Form["password"];
            var refreshToken = context.Request.Form["refresh_token"];

            UserDto user = null;
            Guid jwtId;
            var isRefresh = false;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                user = AuthenticationService.Authenticate(username, password);
            }
            else if (!string.IsNullOrEmpty(refreshToken))
            {
                jwtId = new Guid(refreshToken);

                var token = AuthenticationService.GetToken(jwtId);

                user = AuthenticationService.GetUser(token.UserId);

                isRefresh = true;
            }

            var identity = await GetIdentity(user);

            if (identity == null)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Invalid username or password.");
                return;
            }

            var now = DateTime.UtcNow;

            var roles = await GetRoleClaims(user?.Id ?? -1);

            jwtId = Guid.NewGuid();

            // Specifically add the jti (random nonce), iat (issued timestamp), and sub (subject/user) claims.
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Name),
                new Claim(JwtRegisteredClaimNames.Jti, jwtId.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.Ticks.ToString(), ClaimValueTypes.Integer64)
            };

            claims.AddRange(roles);
            
            // Create the JWT and write it to a string
            var jwt = new JwtSecurityToken (
                    issuer: Options.Issuer,
                    audience: Options.Audience,
                    claims: claims,
                    notBefore: now,
                    expires: now.Add(Options.Expiration),
                    signingCredentials: Options.SigningCredentials);

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                expires_in = (int)Options.Expiration.TotalSeconds
            };

            var tokenDto = new TokenDto
            {
                JwtId = jwtId,
                UserId = user.Id,
                GeneratedDate = now,
                ValidTo = jwt.ValidTo,
                IsRefresh = isRefresh
            };

            AuthenticationService.RegisterToken(tokenDto);

            // Serialize and return the response
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }

        private Task<ClaimsIdentity> GetIdentity(UserDto user)
        {
            // If authenticated
            if (user != null)
            {
                return Task.FromResult(new ClaimsIdentity(new GenericIdentity(user.Id.ToString(), "Token")));
            }

            // Credentials are invalid, or account doesn't exist
            return Task.FromResult<ClaimsIdentity>(null);
        }

        private Task<IEnumerable<Claim>> GetRoleClaims(long userId)
        {
            var claims = new List<Claim>();

            var roles = AuthenticationService.GetRolesByUserId(userId);

            foreach (var role in roles)
            {
                claims.Add(new Claim("role", role));
            }

            return Task.FromResult<IEnumerable<Claim>>(claims);
        }
    }
}
