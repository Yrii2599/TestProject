using DAL.Mapping;
using DAL.Services.Event.Command;
using DAL.Services.Event.Query;
using Domain.Abstraction.Commands;
using Domain.Abstraction.CommonHendler;
using Domain.Abstraction.Queries;
using Domain.Agregate.Event;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Services.Event
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDalDependencyInjection( this IServiceCollection services, IConfiguration configuration )
        {

            services.AddScoped<ICommandHendler<CreateEventDomainModel, IEnumerable<DomainEvent>>, CreateEventCommandHandler> ();
            services.AddScoped<IQuerydHendler<GetEventsForDate, IEnumerable<DomainEvent>>, GetEventByDateQueryHendler> ();
            return services;
        }
    }
}
