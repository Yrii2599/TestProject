using Application.Mapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Configuration
{
    public static  class ApplicationConfiguration
    {
        public static IServiceCollection AddApplicationConfiguration( this IServiceCollection services, IConfiguration configuration )
        {

            services.AddApplicationAutomapperConfiguration (configuration);
            services.AddApplicationDependencyInjection (configuration);
            return services;
        }

        public static IServiceCollection AddApplicationAutomapperConfiguration( this IServiceCollection services, IConfiguration configuration )
        {

            services.AddAutoMapper (typeof (MappingProfiler));
            return services;
        }
    }
}
