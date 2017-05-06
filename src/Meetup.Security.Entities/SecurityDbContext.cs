using Meetup.Security.Entities.Map;
using Microsoft.EntityFrameworkCore;

namespace Meetup.Security.Entities
{
    public class SecurityDbContext : DbContext
    {
        /// <summary>
        /// Construtor padrão para uso dos repositórios do EntityFramework
        /// </summary>
        public SecurityDbContext(DbContextOptions<SecurityDbContext> options)
            : base(options)
        {
        }

        public SecurityDbContext()
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Profile> Profiles { get; set; }

        public virtual DbSet<UserProfile> UserProfiles { get; set; }

        public virtual DbSet<Functionality> Functionalities { get; set; }

        public virtual DbSet<ProfileFunctionality> ProfileFunctionalities { get; set; }

        public virtual DbSet<Token> Tokens { get; set; }

        /// <summary>
        /// Seta as informações do Fluent API
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // domain
            new UserMap(modelBuilder.Entity<User>());
            new ProfileMap(modelBuilder.Entity<Profile>());
            new FunctionalityMap(modelBuilder.Entity<Functionality>());
            new TokenMap(modelBuilder.Entity<Token>());

            // relations
            new ProfileFunctionalityMap(modelBuilder.Entity<ProfileFunctionality>());
            new UserProfileMap(modelBuilder.Entity<UserProfile>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
