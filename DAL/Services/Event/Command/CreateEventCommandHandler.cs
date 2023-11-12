using AutoMapper;
using DAL.Context;
using DAL.Models;
using Domain.Abstraction.Commands;
using Domain.Abstraction.CommonHendler;
using Domain.Agregate.Event;

namespace DAL.Services.Event.Command
{
    public class CreateEventCommandHandler : ICommandHendler<CreateEventDomainModel, IEnumerable<DomainEvent>>
    {
        public DataBaseContext DbContext { get; set; }
        public IMapper Mapper { get; set; }

        public CreateEventCommandHandler( DataBaseContext dbContext, IMapper mapper )
        {
            DbContext = dbContext;
            Mapper = mapper;
        }

        public async Task<IEnumerable<DomainEvent>> Execute( CreateEventDomainModel command )
        {
            IEnumerable<EventEntity> events = Mapper.Map<IEnumerable<DomainEvent>, IEnumerable<EventEntity>> (command.Events);
            events.Select (e => e.Date = command.Date).ToList ();

            await DbContext.Events.AddRangeAsync (events);
            await DbContext.SaveChangesAsync ();

            return Mapper.Map<List<EventEntity>, List<DomainEvent>> (events.ToList ());
        }
    }
}
