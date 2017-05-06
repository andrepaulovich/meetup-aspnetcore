using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Meetup.Security.Shared.Mappers
{
    public static class AutomapperServiceExtension
    {
        public static void AddAutoMapperProfiles(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<SecurityProfile>();
            });

            services.AddSingleton(sp => config.CreateMapper());
        }
    }
}
