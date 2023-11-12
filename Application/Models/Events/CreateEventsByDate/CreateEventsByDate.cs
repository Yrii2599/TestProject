namespace Application.Models.Events.CreateEventsByDate
{
    public class CreateEventsByDate
    {
        public DateOnly Date { get; set; }

        public List<Event>? Events { get; set; }

        public CreateEventsByDate( DateOnly date, List<Event>? events )
        {
            Date = date;
            Events = events;
        }
    }
}
