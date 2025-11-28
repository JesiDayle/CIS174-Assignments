using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OlympicDataTransfer.Models;
using OlympicDataTransfer.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OlympicDataTransfer.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        // Index shows login prompt if user is not signed in
        public async Task<IActionResult> Index()
        {
            var tickets = new List<Ticket>();

            // Only load tickets if the user is logged in
            if (User.Identity.IsAuthenticated)
            {
                tickets = await _ticketService.GetAllTicketsAsync();
            }

            return View(tickets); // always pass a list to avoid null errors
        }

        [Authorize]
        public IActionResult Create() => View(new Ticket());

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ticket ticket)
        {
            if (!ModelState.IsValid) return View(ticket);

            await _ticketService.AddTicketAsync(ticket);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var ticket = await _ticketService.GetTicketByIdAsync(id);
            if (ticket == null) return RedirectToAction(nameof(Index));
            return View(ticket);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Ticket ticket)
        {
            if (!ModelState.IsValid) return View(ticket);

            await _ticketService.UpdateTicketAsync(ticket);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var ticket = await _ticketService.GetTicketByIdAsync(id);
            if (ticket == null) return RedirectToAction(nameof(Index));
            return View(ticket);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _ticketService.DeleteTicketAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var ticket = await _ticketService.GetTicketByIdAsync(id);
            if (ticket == null) return RedirectToAction(nameof(Index));
            return View(ticket);
        }
    }
}

