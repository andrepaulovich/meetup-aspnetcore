using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meetup.Security.Entities.Map
{
    internal class FunctionalityMap
    {
        public FunctionalityMap(EntityTypeBuilder<Functionality> entityBuilder)
        {
            entityBuilder.Property(f => f.Id).ValueGeneratedOnAdd();

            entityBuilder.HasKey(c => c.Id);

            entityBuilder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            entityBuilder.Property(t => t.Code)
                .IsRequired()
                .HasMaxLength(10);
        }
    }
}
