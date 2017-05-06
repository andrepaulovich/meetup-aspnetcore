using Meetup.Security.Shared.Dtos;
using System.Collections.Generic;

namespace Meetup.Security.Shared.BusinessObjects
{
    public interface IAuthenticationService
    {
        bool Authenticate(string login, string password);

        IEnumerable<UserDto> GetUsers();

        UserDto GetUser(long id);
    }
}
