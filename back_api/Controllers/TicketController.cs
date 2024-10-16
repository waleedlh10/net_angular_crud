using back_api.Data;
using back_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly TicketContext _context;

        public TicketController(TicketContext context)
        {
            _context = context;
        }
        

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets(
            int page = 1,
            int items_per_page = 10,
            int? ticketId = null,
            string description = null,
            string status = null,
            DateTime? date = null,
            string order_by = "ticketId", 
            string order_dir = "asc") 
        {
            
            if (items_per_page < 1 || items_per_page > 100)
            {
                return BadRequest("items_per_page must be between 1 and 100.");
            }

            
            IQueryable<Ticket> query = _context.Tickets;

            // Apply filters
            if (ticketId.HasValue)
            {
                query = query.Where(t => t.TicketId == ticketId.Value);
            }

            if (!string.IsNullOrEmpty(description))
            {
                query = query.Where(t => t.Description.Contains(description));
            }

            if (!string.IsNullOrEmpty(status) && status != "All")
            {
                query = query.Where(t => t.Status == status);
            }

            if (date.HasValue)
            {
                query = query.Where(t => t.Date.Date > date.Value.Date);
            }

            // Apply ordering
            switch (order_by.ToLower())
            {
                case "description":
                    query = order_dir.ToLower() == "desc" ? query.OrderByDescending(t => t.Description) : query.OrderBy(t => t.Description);
                    break;
                case "status":
                    query = order_dir.ToLower() == "desc" ? query.OrderByDescending(t => t.Status) : query.OrderBy(t => t.Status);
                    break;
                case "date":
                    query = order_dir.ToLower() == "desc" ? query.OrderByDescending(t => t.Date) : query.OrderBy(t => t.Date);
                    break;
                default: // Default to ordering by ticketId
                    query = order_dir.ToLower() == "desc" ? query.OrderByDescending(t => t.TicketId) : query.OrderBy(t => t.TicketId);
                    break;
            }

            // Calculate total number of tickets after filtering and ordering
            var totalTickets = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalTickets / items_per_page);

            // Retrieve paginated tickets
            var tickets = await query
                .Skip((page - 1) * items_per_page)
                .Take(items_per_page)
                .ToListAsync();

            return Ok(new
            {
                total_pages = totalPages,
                items_per_page,
                page,
                tickets
            });
        }

        

        // GET: api/ticket/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicket(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return ticket;
        }

        // POST: api/ticket
        [HttpPost]
        public async Task<ActionResult<Ticket>> CreateTicket([FromBody] Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTicket), new { id = ticket.TicketId }, ticket);
        }

        // PUT: api/ticket/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(int id, [FromBody] Ticket ticket)
        {
            if (id != ticket.TicketId)
            {
                return BadRequest();
            }

            _context.Entry(ticket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/ticket/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TicketExists(int id)
        {
            return _context.Tickets.Any(e => e.TicketId == id);
        }
    }
}
