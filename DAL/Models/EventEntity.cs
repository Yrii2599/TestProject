using DAL.Models.Abstraction;

namespace DAL.Models
{
    public class EventEntity : IEntity
    {
        public Guid Id { get; set; }

        public DateOnly Date { get; set; }

        public string? Title { get; set; }

        public EventEntity( Guid id, DateOnly date, string? title )
        {
            Id = id;
            Date = date;
            Title = title;
        }
        public EventEntity() :
            this (default, default, default!)
        {

        }
    }
}
