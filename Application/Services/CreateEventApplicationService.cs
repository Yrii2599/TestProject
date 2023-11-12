using Application.Models.Events;
using Application.Models.Events.CreateEventsByDate;
using Application.Models.Events.GetEvetsByDate;
using Application.Services.Abstraction;
using AutoMapper;
using Domain.Abstraction.Commands;
using Domain.Abstraction.CommonHendler;
using Domain.Agregate.Event;
using System.Linq;

namespace Application.Services
{
    public class CreateEventApplicationService : ICreateEventApplicationService
    {
        public ICommandHendler<CreateEventDomainModel, IEnumerable<DomainEvent>> CommandHendler { get; set; }

        public IMapper Mapper { get; set; }

        public CreateEventApplicationService( ICommandHendler<CreateEventDomainModel, IEnumerable<DomainEvent>> commandHendler,
            IMapper mapper )
        {
            CommandHendler = commandHendler;
            Mapper = mapper;
        }

        public async Task<IEnumerable<GetEventsByDate>> CreateEvents( CreateEventsByDate createEventModel )
        {
            IEnumerable<DomainEvent> events = await DomainEvent.CreateEvents (CommandHendler, Mapper.Map<CreateEventsByDate, CreateEventDomainModel> (createEventModel));
            return events
                .GroupBy (e => e.Date)
                .ToList ()
                    .Select (e => new GetEventsByDate (e.Key, Mapper.Map<List<DomainEvent>, List<Event>> (e.Select (c => c).ToList ())));
        }
    }
}
