namespace Application.Models.Events.GetEvetsByDate
{
    public class GetEventsByDate
    {
        public DateOnly Date { get; set; }

        public List<Event>? Events { get; set; }

        public GetEventsByDate( DateOnly date, List<Event>? events )
        {
            Date = date;
            Events = events;
        }
        public GetEventsByDate() : this (default, default!)
        {

        }
    }
}
