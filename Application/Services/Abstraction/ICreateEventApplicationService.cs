using Application.Models.Events.CreateEventsByDate;
using Application.Models.Events.GetEvetsByDate;

namespace Application.Services.Abstraction
{
    public interface ICreateEventApplicationService
    {
        Task<IEnumerable<GetEventsByDate>> CreateEvents( CreateEventsByDate createEventModel );
    }
}
