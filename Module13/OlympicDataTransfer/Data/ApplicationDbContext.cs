using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OlympicDataTransfer.Models;

namespace OlympicDataTransfer.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Add DbSets for each model 
        public DbSet<Ticket> Tickets { get; set; }
    }
}
