using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Principal;

namespace Meetup.Security.Middleware
{
    public static class AuthenticationContextExtension
    {
        /// <summary>
        /// Add IPrincipal to DI so then classes can have IPrincipal as a constructor parameter
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddUserPrincipalToContext(this IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IPrincipal>(provider => provider.GetService<IHttpContextAccessor>().HttpContext.User);

            return services;
        }
    }
}
