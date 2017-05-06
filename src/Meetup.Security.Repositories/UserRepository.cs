using Meetup.Security.Entities;
using Meetup.Security.Shared.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Meetup.Security.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(SecurityDbContext dbContext)
            : base(dbContext)
        {
        }

        public IEnumerable<User> FindByIdList(List<long> usersIds)
        {
            return SecurityDbContext.Users
                          .Where(user => usersIds.Contains(user.Id))
                          .ToList();
        }

        public IEnumerable<User> FindByLoginList(List<string> userLogins)
        {
            return SecurityDbContext.Users
                          .Where(user => userLogins.Contains(user.Login))
                          .ToList();
        }

        public User GetByLogin(string userLogin)
        {
            return SecurityDbContext.Users.SingleOrDefault(u => u.Login.Equals(userLogin));
        }

        public IEnumerable<string> GetRolesByUserId(long userId)
        {
            var listRoles = new List<string>();

            var roles = (from up in SecurityDbContext.UserProfiles
                        join pf in SecurityDbContext.ProfileFunctionalities
                            on up.ProfileId equals pf.ProfileId
                        join f in SecurityDbContext.Functionalities
                            on pf.FunctionalityId equals f.Id
                        where up.UserId == userId
                        select f.Code).Distinct();

                listRoles.AddRange(roles.ToList());

            return listRoles;
        }
    }
}
