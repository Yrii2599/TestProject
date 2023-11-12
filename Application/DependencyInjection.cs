using Application.Services;
using Application.Services.Abstraction;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDependencyInjection( this IServiceCollection services, IConfiguration configuration )
        {

            services.AddScoped<IGetEventApplicationService, GetEventsByDateApplicationService> ();
            services.AddScoped<ICreateEventApplicationService, CreateEventApplicationService> ();
            return services;
        }
    }
}
