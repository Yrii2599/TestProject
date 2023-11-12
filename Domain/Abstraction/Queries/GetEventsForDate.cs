
namespace Domain.Abstraction.Queries
{
    public class GetEventsForDate : IRetrieveRepositoryQuery
    {
        public DateOnly Date { get; set; }

        public GetEventsForDate( DateOnly date )
        {
            Date = date;
        }
    }
}
