using Meetup.Security.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Meetup.Security.Shared.Auth
{
    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class BearerAuthenticationProviderExtension
    {
        // The secret key every token will be signed with.
        // In production, you should store this securely in environment variables
        // or a key management tool. Don't hardcode this into your application!
        private static readonly string SecretKey = "456@supersecret_key@687";

        public static IApplicationBuilder UseBearerAuthenticationTokenProvider(this IApplicationBuilder app)
        {
            // Add JWT generation endpoint:
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));

            var options = new TokenProviderOptions
            {
                Audience = "http://meetup.random.com",
                Issuer = "Paulovich",
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
            };

            return app.UseMiddleware<TokenProviderMiddleware>(Options.Create(options));
        }
    }
}
