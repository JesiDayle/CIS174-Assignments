using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using OlympicDataTransfer.Models;
using System;
using System.Threading.Tasks;

namespace OlympicDataTransfer.Data
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            // Get the UserManager service
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // Admin user credentials
            string adminEmail = "admin@olympics.com";
            string adminPassword = "Admin123!";

            // Check if the admin user exists
            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var adminUser = new ApplicationUser { UserName = adminEmail, Email = adminEmail };
                await userManager.CreateAsync(adminUser, adminPassword);
            }

            // Create a regular user
            string userEmail = "user@olympics.com";
            string userPassword = "User123!";

            if (await userManager.FindByEmailAsync(userEmail) == null)
            {
                var regularUser = new ApplicationUser { UserName = userEmail, Email = userEmail };
                await userManager.CreateAsync(regularUser, userPassword);
            }
        }
    }
}
