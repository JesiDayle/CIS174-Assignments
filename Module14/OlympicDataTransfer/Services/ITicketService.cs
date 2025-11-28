using OlympicDataTransfer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OlympicDataTransfer.Services
{
    public interface ITicketService
    {
        Task<List<Ticket>> GetAllTicketsAsync();
        Task<Ticket?> GetTicketByIdAsync(int id);
        Task AddTicketAsync(Ticket ticket);
        Task UpdateTicketAsync(Ticket ticket);
        Task DeleteTicketAsync(int id);
    }
}