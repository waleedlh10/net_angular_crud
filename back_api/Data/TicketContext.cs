using Microsoft.EntityFrameworkCore;
using back_api.Models;

namespace back_api.Data
{
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options) : base(options)
        {
        }

        public DbSet<Ticket> Tickets { get; set; }

        
    }
}
