using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meetup.Security.Entities.Map
{
    public class ProfileFunctionalityMap
    {
        public ProfileFunctionalityMap(EntityTypeBuilder<ProfileFunctionality> entityBuilder)
        {
            entityBuilder.HasKey(t => new { t.ProfileId, t.FunctionalityId });

            entityBuilder
                .HasOne(pt => pt.Profile)
                .WithMany(t => t.ProfileFunctionalities)
                .HasForeignKey(pt => pt.ProfileId);

            entityBuilder
                .HasOne(pt => pt.Functionality)
                .WithMany(p => p.ProfileFunctionalities)
                .HasForeignKey(pt => pt.FunctionalityId);
        }
    }
}
