using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OlympicDataTransfer.Models;

namespace OlympicDataTransfer.Controllers
{
    public class FavoritesController : Controller
    {
        public IActionResult Index()
        {
            var favorites = GetFavorites();
            return View(favorites);
        }

        [HttpPost]
        public IActionResult AddToFavorites(string country, string game, string sport, string type, string flagPath)
        {
            var favorites = GetFavorites();

            // Check if already added
            if (!favorites.Any(f => f.Country == country && f.Sport == sport))
            {
                favorites.Add(new OlympicEntry
                {
                    Country = country,
                    Game = game,
                    Sport = sport,
                    Type = type,
                    FlagPath = flagPath
                });
                SaveFavorites(favorites);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ClearFavorites()
        {
            HttpContext.Session.Remove("Favorites");
            return RedirectToAction("Index");
        }

        private List<OlympicEntry> GetFavorites()
        {
            var json = HttpContext.Session.GetString("Favorites");
            return string.IsNullOrEmpty(json) ? new List<OlympicEntry>() :
                JsonConvert.DeserializeObject<List<OlympicEntry>>(json);
        }

        private void SaveFavorites(List<OlympicEntry> favorites)
        {
            var json = JsonConvert.SerializeObject(favorites);
            HttpContext.Session.SetString("Favorites", json);
        }
    }
}
