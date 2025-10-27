using System.Collections.Generic;
using System.Linq;

namespace OlympicDataTransfer.Models
{
    public static class TicketRepository
    {
        private static List<Ticket> _tickets = new List<Ticket>();
        private static int _nextId = 1;

        public static List<Ticket> GetAll() => _tickets;

        public static void Add(Ticket ticket)
        {
            ticket.Id = _nextId++;
            _tickets.Add(ticket);
        }

        public static Ticket? Get(int id) => _tickets.FirstOrDefault(t => t.Id == id);

        public static void Update(Ticket ticket)
        {
            var existing = Get(ticket.Id);
            if (existing != null)
            {
                existing.Name = ticket.Name;
                existing.Description = ticket.Description;
                existing.SprintNumber = ticket.SprintNumber;
                existing.Points = ticket.Points;
                existing.Status = ticket.Status;
            }
        }

        public static void Delete(int id)
        {
            var ticket = Get(id);
            if (ticket != null)
                _tickets.Remove(ticket);
        }
    }
}
