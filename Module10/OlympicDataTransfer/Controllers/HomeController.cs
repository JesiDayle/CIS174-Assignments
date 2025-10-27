using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OlympicDataTransfer.Models;
using System.Linq;
using System.Collections.Generic;

namespace OlympicDataTransfer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index(OlympicFilterViewModel model)
        {
            // Get all entries from repository
            var allEntries = OlympicRepository.GetAll();

            // Apply filters: 'ALL' means no filter for that field
            var filteredEntries = allEntries
                .Where(e => (string.IsNullOrEmpty(model.GameFilter) || model.GameFilter == "ALL" || e.Game == model.GameFilter)
                         && (string.IsNullOrEmpty(model.TypeFilter) || model.TypeFilter == "ALL" || e.Type == model.TypeFilter))
                .OrderBy(e => e.Country)
                .ToList();

            // Favorites count from session
            var favoritesJson = HttpContext.Session.GetString("Favorites");
            int favCount = 0;
            if (!string.IsNullOrEmpty(favoritesJson))
            {
                var favoritesList = JsonConvert.DeserializeObject<List<OlympicEntry>>(favoritesJson);
                favCount = favoritesList.Count;
            }

            // Populate ViewModel
            model.Entries = filteredEntries;
            model.FavoriteCount = favCount;
            model.Games = allEntries.Select(e => e.Game).Distinct().ToList();
            model.Types = allEntries.Select(e => e.Type).Distinct().ToList();

            return View(model);
        }

        public IActionResult Details(string country)
        {
            if (string.IsNullOrEmpty(country))
                return RedirectToAction("Index");

            var entry = OlympicRepository.GetAll().FirstOrDefault(e => e.Country == country);
            if (entry == null)
                return RedirectToAction("Index");

            // Favorites count for layout
            var favoritesJson = HttpContext.Session.GetString("Favorites");
            int favCount = 0;
            if (!string.IsNullOrEmpty(favoritesJson))
            {
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
