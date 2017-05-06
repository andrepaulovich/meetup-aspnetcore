using Meetup.Security.Entities;
using Meetup.Security.Shared.Repositories;

namespace Meetup.Security.Repositories
{
    public class FunctionalityRepository : Repository<Functionality>, IFunctionalityRepository
    {
        public FunctionalityRepository(SecurityDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
