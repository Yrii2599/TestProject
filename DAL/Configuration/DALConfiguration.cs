using DAL.Context;
using DAL.Mapping;
using DAL.Services.Event;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Configuration
{
    public static class DALConfiguration
    {
        public static IServiceCollection AddDalConfiguration( this IServiceCollection services, IConfiguration configuration )
        {

            services.AddEFCoreConfiguration(configuration);
            services.AddDalAutomapperConfiguration (configuration);
            services.AddDalDependencyInjection (configuration);
            return services;
        }

        public static IServiceCollection AddEFCoreConfiguration( this IServiceCollection services, IConfiguration configuration )
        {

            services.AddEntityFrameworkNpgsql ()
                .AddDbContext<DataBaseContext> (opt =>
                opt.UseNpgsql (configuration.GetConnectionString ("WebApiConection")));
            return services;
        }

        public static IServiceCollection AddDalAutomapperConfiguration( this IServiceCollection services, IConfiguration configuration )
        {

            services.AddAutoMapper (typeof (DalMappingProfiler));
            return services;
        }
    }
}
