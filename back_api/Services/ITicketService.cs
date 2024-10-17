using back_api.Models;

namespace back_api.Services
{
    public interface ITicketService
    {
        Task<Ticket> GetTicketByIdAsync(int id);
    }
}
