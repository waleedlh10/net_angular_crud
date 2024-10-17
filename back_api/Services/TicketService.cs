
using back_api.Data;
using back_api.Models;

namespace back_api.Services
{
    public class TicketService : ITicketService
    {
        private readonly TicketContext _context;

        public TicketService(TicketContext context)
        {
            _context = context;
        }

        public async Task<Ticket> GetTicketByIdAsync(int id)
        {
            return await _context.Tickets.FindAsync(id);
        }
    }
}
