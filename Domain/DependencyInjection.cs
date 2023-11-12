using Domain.Abstraction;
using Domain.Abstraction.Commands;
using Domain.Abstraction.Queries;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Domain
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomainDependencyInjection( this IServiceCollection services, IConfiguration configuration )
        {

            services.AddScoped<IRetrieveRepositoryQuery, GetEventsForDate> ();
            services.AddScoped<ICreateRepositoryCommand, CreateEventDomainModel> ();
            return services;
        }
    }
}
