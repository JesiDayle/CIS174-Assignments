using System.Collections.Generic;

namespace OlympicDataTransfer.Models
{
    public class OlympicFilterViewModel
    {
        // Filters
        public string GameFilter { get; set; } = "ALL";
        public string TypeFilter { get; set; } = "ALL";

        // List of entries to display
        public List<OlympicEntry> Entries { get; set; } = new();

        // Filter dropdowns
        public List<string> Games { get; set; } = new();
        public List<string> Types { get; set; } = new();

        // Favorites count from session
        public int FavoriteCount { get; set; } = 0;
    }
}
