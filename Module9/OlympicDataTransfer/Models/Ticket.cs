using System;

namespace OlympicDataTransfer.Models
{
    public class Ticket
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int SprintNumber { get; set; }
        public int Points { get; set; }
        public string Status { get; set; } = "To Do"; 
    }
}