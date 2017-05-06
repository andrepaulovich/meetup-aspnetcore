using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meetup.Security.Entities.Map
{
    internal class TokenMap
    {
        public TokenMap(EntityTypeBuilder<Token> entityBuilder)
        {
            entityBuilder.HasKey(c => c.Id);
            entityBuilder.Property(f => f.Id).ValueGeneratedOnAdd();

            entityBuilder.Property(t => t.ValidTo)
                .IsRequired();

            entityBuilder.Property(t => t.GeneratedDate)
                .IsRequired();

            entityBuilder.Property(t => t.JwtId)
                .IsRequired();

            entityBuilder.Property(t => t.UserId)
                .IsRequired();

            entityBuilder.Property(t => t.BlackList)
                .HasDefaultValue(false)
                .IsRequired();
        }
    }
}