using Microsoft.AspNetCore.Mvc;
using OlympicDataTransfer.Models;

namespace OlympicDataTransfer.Controllers
{
    public class TicketsController : Controller
    {
        public IActionResult Index()
        {
            var tickets = TicketRepository.GetAll();
            return View(tickets);
        }

        public IActionResult Create()
        {
            return View(new Ticket());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ticket ticket)
        {
            if (!ModelState.IsValid)
                return View(ticket);

            TicketRepository.Add(ticket);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var ticket = TicketRepository.Get(id);
            if (ticket == null) return RedirectToAction(nameof(Index));
            return View(ticket);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Ticket ticket)
        {
            if (!ModelState.IsValid)
                return View(ticket);

            TicketRepository.Update(ticket);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var ticket = TicketRepository.Get(id);
            if (ticket == null) return RedirectToAction(nameof(Index));
            return View(ticket); 
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            TicketRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
