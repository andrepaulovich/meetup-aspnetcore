using Meetup.Security.Entities;
using Meetup.Security.Shared.Repositories;

namespace Meetup.Security.Repositories
{
    public class ProfileRepository : Repository<Profile>, IProfileRepository
    {
        public ProfileRepository(SecurityDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
