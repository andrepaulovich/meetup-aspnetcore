using Meetup.Security.Entities;
using System.Collections.Generic;

namespace Meetup.Security.Shared.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByLogin(string userLogin);

        IEnumerable<User> FindByIdList(List<long> usersIds);

        IEnumerable<User> FindByLoginList(List<string> userLogins);

        IEnumerable<string> GetRolesByUserId(long userId);
    }
}
