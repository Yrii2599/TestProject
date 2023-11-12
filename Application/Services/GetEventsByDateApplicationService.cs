using Application.Models.Events;
using Application.Models.Events.GetEvetsByDate;
using Application.Services.Abstraction;
using AutoMapper;
using Domain.Abstraction.CommonHendler;
using Domain.Abstraction.Queries;
using Domain.Agregate.Event;

namespace Application.Services
{
    public class GetEventsByDateApplicationService : IGetEventApplicationService
    {
        public IQuerydHendler<GetEventsForDate, IEnumerable<DomainEvent>> QuerydHendler { get; set; }
        public IMapper Mapper { get; set; }

        public GetEventsByDateApplicationService( IQuerydHendler<GetEventsForDate, IEnumerable<DomainEvent>> querydHendler,
            IMapper mapper )
        {
            QuerydHendler = querydHendler;
            Mapper = mapper;
        }

        public async Task<IEnumerable<GetEventsByDate>> GetEventsByDate( DateOnly date )
        {
            IEnumerable<DomainEvent> events = await DomainEvent.GetEvents (QuerydHendler, new GetEventsForDate (date));
            return events
                .GroupBy (e => e.Date)
                .ToList ()
                    .Select (e => new GetEventsByDate (e.Key, Mapper.Map<List<DomainEvent>, List<Event>> (e.Select (c => c).ToList ())));
        }
    }
}
