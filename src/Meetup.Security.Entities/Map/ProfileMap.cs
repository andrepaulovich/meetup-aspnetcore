using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meetup.Security.Entities.Map
{
    internal class ProfileMap
    {
        public ProfileMap(EntityTypeBuilder<Profile> entityBuilder)
        {
            entityBuilder.Property(f => f.Id).ValueGeneratedOnAdd();

            entityBuilder.HasKey(c => c.Id);

            entityBuilder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}