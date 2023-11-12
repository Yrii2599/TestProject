using Domain.Agregate.Event;

namespace Domain.Abstraction.Commands
{
    public class CreateEventDomainModel : ICreateRepositoryCommand
    {
        public List<DomainEvent> Events { get; set; }

        public DateOnly Date { get; set; }

        public CreateEventDomainModel( List<DomainEvent> events, DateOnly date )
        {
            Events = events;
            Date = date;
        }
    }
}
