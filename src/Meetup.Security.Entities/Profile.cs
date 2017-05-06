using System.Collections.Generic;

namespace Meetup.Security.Entities
{
    public class Profile
    {
        public Profile()
        {
            this.ProfileFunctionalities = new List<ProfileFunctionality>();
            this.UserProfiles = new List<UserProfile>();
        }

        public long Id { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }

        public virtual ICollection<ProfileFunctionality> ProfileFunctionalities { get; set; }

        public virtual ICollection<UserProfile> UserProfiles { get; set; }
    }
}
