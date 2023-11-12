using DAL.Models.Abstraction;
using Domain.Abstraction.Commands;
using Domain.Abstraction.CommonHendler;
using Domain.Abstraction.Queries;

namespace Domain.Agregate.Event
{
    public class DomainEvent : IDomainEntity
    {
        public Guid Id { get; set; }

        public DateOnly Date { get; set; }

        public string? Title { get; set; }

        public DomainEvent( Guid id, DateOnly date, string? title )
        {
            Id = id;
            Date = date;
            Title = title;
        }

        public DomainEvent()
            : this(default, default, default!)
        {
            Id = Guid.NewGuid();
        }

        public static async Task<IEnumerable<DomainEvent>> GetEvents( IQuerydHendler<GetEventsForDate, IEnumerable<DomainEvent>> querydHendler, GetEventsForDate query) =>
            await querydHendler.Execute (query);

        public static async Task<IEnumerable<DomainEvent>> CreateEvents( ICommandHendler<CreateEventDomainModel, IEnumerable<DomainEvent>> commandHendler, CreateEventDomainModel query ) =>
            await commandHendler.Execute (query);
    }
}
