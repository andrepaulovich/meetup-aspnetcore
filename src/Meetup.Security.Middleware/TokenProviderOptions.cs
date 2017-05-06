using Microsoft.IdentityModel.Tokens;
using System;

namespace Meetup.Security.Middleware
{
    public class TokenProviderOptions
    {
        public TokenProviderOptions()
        {
            this.Path = @"/token";
            this.Expiration = TimeSpan.FromDays(1);
        }

        public string Path { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public TimeSpan Expiration { get; set; }

        public SigningCredentials SigningCredentials { get; set; }
    }
}
