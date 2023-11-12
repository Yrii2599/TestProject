using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class DataBaseContext : DbContext
    {
        public DbSet<EventEntity> Events { get; set; }

        public DataBaseContext( DbContextOptions<DataBaseContext> options ) : base (options) 
        { }
    }
}
