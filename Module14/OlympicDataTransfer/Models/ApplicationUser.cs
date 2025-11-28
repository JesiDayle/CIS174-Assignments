using Microsoft.AspNetCore.Identity;

namespace OlympicDataTransfer.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
    }
}
