using Application.Models.Events;
using Application.Models.Events.CreateEventsByDate;
using Application.Models.Events.GetEvetsByDate;
using AutoMapper;
using Domain.Abstraction.Commands;
using Domain.Agregate.Event;

namespace Application.Mapper
{
    public class MappingProfiler : Profile
    {
        public MappingProfiler()
        {
            CreateMap<DomainEvent, Event> ();
            CreateMap<Event, DomainEvent> ();
            CreateMap<CreateEventsByDate, CreateEventDomainModel> ();
            CreateMap<DomainEvent, GetEventsByDate> ();
        }
    }
}
