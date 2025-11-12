using Microsoft.AspNetCore.Mvc;
using Moq;
using OlympicDataTransfer.Controllers;
using OlympicDataTransfer.Models;
using OlympicDataTransfer.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace OlympicDataTransfer.Tests.Controllers
{
    public class TicketsControllerTests
    {
        private readonly Mock<ITicketService> _mockService;
        private readonly TicketsController _controller;

        public TicketsControllerTests()
        {
            _mockService = new Mock<ITicketService>();
            _controller = new TicketsController(_mockService.Object);
        }

        [Fact]
        public async Task Index_ReturnsViewWithTickets()
        {
            var fakeTickets = new List<Ticket>
            {
                new Ticket { Id = 1, Name = "Ticket1" },
                new Ticket { Id = 2, Name = "Ticket2" }
            };
            _mockService.Setup(s => s.GetAllTicketsAsync()).ReturnsAsync(fakeTickets);

            var result = await _controller.Index() as ViewResult;

            Assert.NotNull(result);
            Assert.IsType<List<Ticket>>(result!.Model);
            var model = result.Model as List<Ticket>;
            Assert.Equal(2, model!.Count);
        }

        [Fact]
        public async Task Create_Post_ValidModel_RedirectsToIndex()
        {
            var ticket = new Ticket { Name = "New Ticket", Description = "Desc", SprintNumber = 1, Points = 5, Status = "To Do" };
            _mockService.Setup(s => s.AddTicketAsync(ticket)).Returns(Task.CompletedTask);

            var result = await _controller.Create(ticket) as RedirectToActionResult;

            Assert.NotNull(result);
            Assert.Equal("Index", result!.ActionName);
        }

        [Fact]
        public async Task Create_Post_InvalidModel_ReturnsView()
        {
            _controller.ModelState.AddModelError("Name", "Required");
            var ticket = new Ticket();

            var result = await _controller.Create(ticket) as ViewResult;

            Assert.NotNull(result);
            Assert.Equal(ticket, result!.Model);
        }

        [Fact]
        public async Task Edit_Get_ReturnsViewWithTicket()
        {
            var ticket = new Ticket { Id = 1, Name = "EditMe" };
            _mockService.Setup(s => s.GetTicketByIdAsync(1)).ReturnsAsync(ticket);

            var result = await _controller.Edit(1) as ViewResult;

            Assert.NotNull(result);
            Assert.Equal(ticket, result!.Model);
        }

        [Fact]
        public async Task DeleteConfirmed_RemovesTicketAndRedirects()
        {
            var ticketId = 1;
            _mockService.Setup(s => s.DeleteTicketAsync(ticketId)).Returns(Task.CompletedTask);

            var result = await _controller.DeleteConfirmed(ticketId) as RedirectToActionResult;

            Assert.NotNull(result);
            Assert.Equal("Index", result!.ActionName);
        }
    }
}
