using Meetup.Security.Shared.BusinessObjects;
using Microsoft.Extensions.DependencyInjection;

namespace Meetup.Security.BusinessObjects
{
    public static class BusinessObjectExtension
    {
        public static IServiceCollection AddSecurityBusinessObjects(this IServiceCollection services)
        {
            services.AddTransient<IGoalAuthenticationService, GoalAuthenticationService>();
            return services;
        }
    }
}
