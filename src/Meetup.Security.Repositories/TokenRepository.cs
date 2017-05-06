using Meetup.Security.Entities;
using Meetup.Security.Shared.Repositories;
using System;
using System.Linq;

namespace Meetup.Security.Repositories
{
    public class TokenRepository : Repository<Token>, ITokenRepository
    {
        public TokenRepository(SecurityDbContext dbContext)
            : base(dbContext)
        {
        }

        public Token GetByJwtId(Guid jwtId)
        {
            var token = SecurityDbContext.Tokens
                          .FirstOrDefault(t => t.JwtId == jwtId && !t.BlackList);
            return token;
        }
    }
}
