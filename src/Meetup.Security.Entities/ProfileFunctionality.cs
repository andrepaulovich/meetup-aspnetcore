namespace Meetup.Security.Entities
{
    public class ProfileFunctionality
    {
        public long FunctionalityId { get; set; }

        public long ProfileId { get; set; }

        public virtual Profile Profile { get; set; }

        public virtual Functionality Functionality { get; set; }
    }
}
