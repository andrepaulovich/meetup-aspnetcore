using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meetup.Security.Entities.Map
{
    internal class UserProfileMap
    {
        public UserProfileMap(EntityTypeBuilder<UserProfile> entityBuilder)
        {
            entityBuilder.HasKey(t => new { t.UserId, t.ProfileId });

            entityBuilder
                .HasOne(pt => pt.User)
                .WithMany(t => t.UserProfiles)
                .HasForeignKey(pt => pt.UserId);

            entityBuilder
                .HasOne(pt => pt.Profile)
                .WithMany(p => p.UserProfiles)
                .HasForeignKey(pt => pt.ProfileId);
        }
    }
}
