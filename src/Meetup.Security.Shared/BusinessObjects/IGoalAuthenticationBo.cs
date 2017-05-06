using Meetup.Security.Shared.Dtos;
using System;
using System.Collections.Generic;

namespace Meetup.Security.Shared.BusinessObjects
{
    public interface IGoalAuthenticationService
    {
        UserDto Authenticate(string login, string password);

        IEnumerable<string> GetRolesByUserId(long userId);

        IEnumerable<UserDto> GetUsers();

        UserDto GetUser(long id);

        void RegisterToken(TokenDto token);

        TokenDto GetToken(Guid refreshToken);
    }
}
