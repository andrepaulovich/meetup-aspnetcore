using Meetup.Security.Entities;
using System;

namespace Meetup.Security.Shared.Repositories
{
    public interface ITokenRepository : IRepository<Token>
    {
        Token GetByJwtId(Guid jwtId);
    }
}
