using Microsoft.AspNetCore.Mvc;
using OlympicDataTransfer.Models;
using System.Linq;
using System.Collections.Generic;

namespace OlympicDataTransfer.Controllers
{
    public class OlympicController : Controller
    {
        public IActionResult Index(string game = "ALL", string type = "ALL")
        {
            var data = OlympicRepository.GetAll(); 

            if (!string.IsNullOrEmpty(game) && game != "ALL")
                data = data.Where(x => x.Game == game).ToList();

            if (!string.IsNullOrEmpty(type) && type != "ALL")
                data = data.Where(x => x.Type == type).ToList();

            ViewBag.Game = game;
            ViewBag.Type = type;

            return View(data);
        }
    }
}


