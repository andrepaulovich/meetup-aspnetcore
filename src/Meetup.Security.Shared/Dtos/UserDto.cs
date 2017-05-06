using System.Collections.Generic;

namespace Meetup.Security.Shared.Dtos
{
    public class UserDto : UserBaseDto
    {
        public long Id { get; set; }

        public string Cpf { get; set; }

        public ICollection<UserProfileDto> UserProfiles { get; set; }
    }
}
