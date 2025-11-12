using Microsoft.EntityFrameworkCore;
using OlympicDataTransfer.Data;
using OlympicDataTransfer.Models;
using OlympicDataTransfer.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace OlympicDataTransfer.Tests.Services
{
    public class TicketServiceTests
    {
        private async Task<ApplicationDbContext> GetInMemoryDbContextAsync()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new ApplicationDbContext(options);
            await context.Database.EnsureCreatedAsync();
            return context;
        }

        [Fact]
        public async Task AddTicketAsync_ShouldAddTicket()
        {
            var context = await GetInMemoryDbContextAsync();
            var service = new TicketService(context);
            var ticket = new Ticket { Name = "Test Ticket", Description = "Test Description", SprintNumber = 1, Points = 10, Status = "To Do" };

            await service.AddTicketAsync(ticket);
            var tickets = await service.GetAllTicketsAsync();

            Assert.Single(tickets);
            Assert.Equal("Test Ticket", tickets[0].Name);
        }

        [Fact]
        public async Task GetAllTicketsAsync_ShouldReturnAllTickets()
        {
            var context = await GetInMemoryDbContextAsync();
            var service = new TicketService(context);
            context.Tickets.Add(new Ticket { Name = "Ticket1", Description = "Desc1", SprintNumber = 1, Points = 5, Status = "To Do" });
            context.Tickets.Add(new Ticket { Name = "Ticket2", Description = "Desc2", SprintNumber = 2, Points = 8, Status = "Done" });
            await context.SaveChangesAsync();

            var result = await service.GetAllTicketsAsync();
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetTicketByIdAsync_ShouldReturnCorrectTicket()
        {
            var context = await GetInMemoryDbContextAsync();
            var service = new TicketService(context);
            var ticket = new Ticket { Name = "FindMe", Description = "Test", SprintNumber = 3, Points = 15, Status = "Doing" };
            context.Tickets.Add(ticket);
            await context.SaveChangesAsync();

            var found = await service.GetTicketByIdAsync(ticket.Id);
            Assert.NotNull(found);
            Assert.Equal("FindMe", found!.Name);
        }

        [Fact]
        public async Task UpdateTicketAsync_ShouldChangeTicketDetails()
        {
            var context = await GetInMemoryDbContextAsync();
            var service = new TicketService(context);
            var ticket = new Ticket { Name = "Old", Description = "Old Desc", SprintNumber = 1, Points = 5, Status = "To Do" };
            context.Tickets.Add(ticket);
            await context.SaveChangesAsync();

            ticket.Name = "Updated";
            await service.UpdateTicketAsync(ticket);
            var updated = await service.GetTicketByIdAsync(ticket.Id);

            Assert.Equal("Updated", updated!.Name);
        }

        [Fact]
        public async Task DeleteTicketAsync_ShouldRemoveTicket()
        {
            var context = await GetInMemoryDbContextAsync();
            var service = new TicketService(context);
            var ticket = new Ticket { Name = "DeleteMe", Description = "To delete", SprintNumber = 1, Points = 5, Status = "To Do" };
            context.Tickets.Add(ticket);
            await context.SaveChangesAsync();

            await service.DeleteTicketAsync(ticket.Id);
            var allTickets = await service.GetAllTicketsAsync();

            Assert.Empty(allTickets);
        }
    }
}
