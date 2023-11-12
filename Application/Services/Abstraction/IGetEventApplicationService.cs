using Application.Models.Events.GetEvetsByDate;

namespace Application.Services.Abstraction
{
    public interface IGetEventApplicationService
    {
        Task<IEnumerable<GetEventsByDate>> GetEventsByDate(DateOnly date);
    }
}
