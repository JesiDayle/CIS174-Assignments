using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OlympicDataTransfer.Data;
using OlympicDataTransfer.Models;
using OlympicDataTransfer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

// Add DbContext with SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add ASP.NET Core Identity + Roles
builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>();

// Add TicketService
builder.Services.AddScoped<ITicketService, TicketService>();

var app = builder.Build();

// Seed admin/test user
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await SeedData.Initialize(services);
}

// Configure HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

// Routes
app.MapControllerRoute(
    name: "olympic",
    pattern: "olympic/{action=Index}/{id?}",
    defaults: new { controller = "Home" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages(); 
app.Run();
