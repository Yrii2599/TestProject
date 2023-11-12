using Application.Models.Events.CreateEventsByDate;
using Application.Models.Events.GetEvetsByDate;
using Application.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Globalization;

namespace API.Controllers
{
    [ApiController]
    [SwaggerTag ("Events")]
    [Route ("api/events")]
    public class EventController : ControllerBase
    {
        public IGetEventApplicationService GetEventService { get; set; }
        public ICreateEventApplicationService CreateEventService { get; set; }

        public EventController( IGetEventApplicationService getEventService, ICreateEventApplicationService createEventService )
        {
            GetEventService = getEventService;
            CreateEventService = createEventService;
        }

        [HttpGet]
        public async Task<IEnumerable<GetEventsByDate>> RetrieveEventsByDate( [FromQuery] int year, [FromQuery] string month )
        {
            int mounthParsed = DateTime.ParseExact (month, "MMMM", CultureInfo.CurrentCulture).Month;
            DateOnly date = new DateOnly (year, mounthParsed, 1);

            return await GetEventService.GetEventsByDate (date);
        }


        [HttpPost]
        public async Task<ActionResult> CreateEvents( [FromBody] CreateEventsByDate model )
        {
            IEnumerable<GetEventsByDate> events = await CreateEventService.CreateEvents (model);
            return Created ("", events);
        }
    }
}
