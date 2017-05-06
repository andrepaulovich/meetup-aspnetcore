using System.Collections.Generic;

namespace Meetup.Security.Shared.Dtos
{
    public class UserProfileDto
    {
        public long UserId { get; set; }

        public long ProfileId { get; set; }

        public ProfileDto Profile { get; set; }
    }
}
