using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OlympicDataTransfer.Models;

namespace OlympicDataTransfer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string gameFilter = "ALL", string typeFilter = "ALL")
        {
            var entries = OlympicRepository.GetAll();

            // Apply filters if not ALL
            if (gameFilter != "ALL")
                entries = entries.Where(e => e.Game == gameFilter).ToList();

            if (typeFilter != "ALL")
                entries = entries.Where(e => e.Type == typeFilter).ToList();

            // Alphabetical by Country
            entries = entries.OrderBy(e => e.Country).ToList();

            // Favorites from session
            var favoritesJson = HttpContext.Session.GetString("Favorites");
            int favCount = 0;
            if (!string.IsNullOrEmpty(favoritesJson))
            {
                // Deserialize as List<OlympicEntry>
                var favoritesList = JsonConvert.DeserializeObject<List<OlympicEntry>>(favoritesJson);
                favCount = favoritesList.Count;
            }
            ViewBag.FavoriteCount = favCount;

            // Pass filter selections to view for dropdowns
            ViewBag.SelectedGame = gameFilter;
            ViewBag.SelectedType = typeFilter;

            // Provide list of games and types for filters
            ViewBag.Games = OlympicRepository.GetAll().Select(e => e.Game).Distinct().ToList();
            ViewBag.Types = OlympicRepository.GetAll().Select(e => e.Type).Distinct().ToList();

            return View(entries); // list of OlympicEntry
        }

        public IActionResult Details(string country)
        {
            if (string.IsNullOrEmpty(country)) return RedirectToAction("Index");

            var entry = OlympicRepository.GetAll().FirstOrDefault(e => e.Country == country);
            if (entry == null) return RedirectToAction("Index");

            // Favorites count for layout
            var favoritesJson = HttpContext.Session.GetString("Favorites");
            int favCount = 0;
            if (!string.IsNullOrEmpty(favoritesJson))
            {
                // Deserialize as List<OlympicEntry>
                var favoritesList = JsonConvert.DeserializeObject<List<OlympicEntry>>(favoritesJson);
                favCount = favoritesList.Count;
            }
            ViewBag.FavoriteCount = favCount;

            return View(entry);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}

