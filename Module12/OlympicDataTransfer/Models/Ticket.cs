using System.ComponentModel.DataAnnotations;

namespace OlympicDataTransfer.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; } = string.Empty;

        [Range(1, int.MaxValue, ErrorMessage = "Sprint number must be at least 1.")]
        public int SprintNumber { get; set; }

        [Range(0, 100, ErrorMessage = "Points must be between 0 and 100.")]
        public int Points { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; } = "To Do";
    }
}
