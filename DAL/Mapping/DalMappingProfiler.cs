using AutoMapper;
using DAL.Models;
using Domain.Agregate.Event;
using System;

namespace DAL.Mapping
{
    public class DalMappingProfiler : Profile
    {
        public DalMappingProfiler()
        {
            CreateMap<EventEntity, DomainEvent> ();
            CreateMap<DomainEvent, EventEntity> ();
        }
    }
}
