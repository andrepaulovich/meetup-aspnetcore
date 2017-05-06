using Meetup.Security.Entities;
using System.Collections.Generic;

namespace Meetup.Security.Shared.Dtos
{
    public class ProfileDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }

        public ICollection<ProfileFunctionalityDto> ProfileFunctionalities { get; set; }
    }
}
