using Meetup.Security.Entities;
using Meetup.Security.Shared.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Meetup.Security.Repositories
{
    public static class RepositoryExtension
    {
        public static IServiceCollection AddSecurityRepositories(this IServiceCollection services)
        {
            services.AddDbContext<SecurityDbContext>(opt => opt.UseInMemoryDatabase());
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IProfileRepository, ProfileRepository>();
            services.AddTransient<ITokenRepository, TokenRepository>();
            return services;
        }
    }
}
