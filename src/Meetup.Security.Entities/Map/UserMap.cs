using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meetup.Security.Entities.Map
{
    internal class UserMap
    {
        public UserMap(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.HasKey(c => c.Id);
            entityBuilder.Property(f => f.Id).ValueGeneratedOnAdd();

            entityBuilder.Property(t => t.Login)
                .IsRequired()
                .HasMaxLength(50);

            entityBuilder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            entityBuilder.Property(t => t.Password)
                .IsRequired()
                .HasMaxLength(100);

            entityBuilder.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(100);

            entityBuilder.Property(t => t.Cpf)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}