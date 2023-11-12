using AutoMapper;
using DAL.Context;
using DAL.Models;
using Domain.Abstraction.CommonHendler;
using Domain.Abstraction.Queries;
using Domain.Agregate.Event;
using Microsoft.EntityFrameworkCore;

namespace DAL.Services.Event.Query
{
    internal class GetEventByDateQueryHendler : IQuerydHendler<GetEventsForDate, IEnumerable<DomainEvent>>
    {
        public DataBaseContext DbContext { get; set; }

        public IMapper Mapper { get; set; }

        public GetEventByDateQueryHendler( DataBaseContext dbContext, IMapper mapper )
        {
            DbContext = dbContext;
            Mapper = mapper;
        }
        public async Task<IEnumerable<DomainEvent>> Execute( GetEventsForDate command )
        {
            List<EventEntity> events = await DbContext.Events
                .Where (e => e.Date.Year == command.Date.Year
                && e.Date.Month == command.Date.Month)
                .ToListAsync ();
            return Mapper.Map<List<EventEntity>, List<DomainEvent>> (events);
        }
    }
}
