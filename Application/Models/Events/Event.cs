namespace Application.Models.Events
{
    public class Event
    {
        public string? Title { get; set; }

        public Event( string? title )
        {
            Title = title;
        }
    }
}
