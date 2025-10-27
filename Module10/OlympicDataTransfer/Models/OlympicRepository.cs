using System.Collections.Generic;
using System.Linq;

namespace OlympicDataTransfer.Models
{
    public static class OlympicRepository
    {
        public static List<OlympicEntry> GetAll() => new List<OlympicEntry>
        {
            new OlympicEntry { Country="Canada", Game="Winter Olympics", Sport="Curling", Type="Indoor", FlagPath="/Flags/canada.png"},
            new OlympicEntry { Country="Sweden", Game="Winter Olympics", Sport="Curling", Type="Indoor", FlagPath="/Flags/sweden.png"},
            new OlympicEntry { Country="Great Britain", Game="Winter Olympics", Sport="Curling", Type="Indoor", FlagPath="/Flags/greatbritain.png"},
            new OlympicEntry { Country="Jamaica", Game="Winter Olympics", Sport="Bobsleigh", Type="Outdoor", FlagPath="/Flags/jamaica.png"},
            new OlympicEntry { Country="Italy", Game="Winter Olympics", Sport="Bobsleigh", Type="Outdoor", FlagPath="/Flags/italy.png"},
            new OlympicEntry { Country="Japan", Game="Winter Olympics", Sport="Bobsleigh", Type="Outdoor", FlagPath="/Flags/japan.png"},
            new OlympicEntry { Country="Germany", Game="Summer Olympics", Sport="Diving", Type="Indoor", FlagPath="/Flags/germany.png"},
            new OlympicEntry { Country="China", Game="Summer Olympics", Sport="Diving", Type="Indoor", FlagPath="/Flags/china.png"},
            new OlympicEntry { Country="Mexico", Game="Summer Olympics", Sport="Diving", Type="Indoor", FlagPath="/Flags/mexico.png"},
            new OlympicEntry { Country="Brazil", Game="Summer Olympics", Sport="Road Cycling", Type="Outdoor", FlagPath="/Flags/brazil.png"},
            new OlympicEntry { Country="Netherlands", Game="Summer Olympics", Sport="Cycling", Type="Outdoor", FlagPath="/Flags/netherlands.png"},
            new OlympicEntry { Country="USA", Game="Summer Olympics", Sport="Road Cycling", Type="Outdoor", FlagPath="/Flags/usa.png"},
            new OlympicEntry { Country="Thailand", Game="Paralympics", Sport="Archery", Type="Indoor", FlagPath="/Flags/thailand.png"},
            new OlympicEntry { Country="Uruguay", Game="Paralympics", Sport="Archery", Type="Indoor", FlagPath="/Flags/uruguay.png"},
            new OlympicEntry { Country="Ukraine", Game="Paralympics", Sport="Archery", Type="Indoor", FlagPath="/Flags/ukraine.png"},
            new OlympicEntry { Country="Austria", Game="Paralympics", Sport="Canoe Sprint", Type="Outdoor", FlagPath="/Flags/austria.png"},
            new OlympicEntry { Country="Pakistan", Game="Paralympics", Sport="Canoe Sprint", Type="Outdoor", FlagPath="/Flags/pakistan.png"},
            new OlympicEntry { Country="Zimbabwe", Game="Paralympics", Sport="Canoe Sprint", Type="Outdoor", FlagPath="/Flags/zimbabwe.png"},
            new OlympicEntry { Country="France", Game="Youth Olympic Games", Sport="Breakdancing", Type="Indoor", FlagPath="/Flags/france.png"},
            new OlympicEntry { Country="Cyprus", Game="Youth Olympic Games", Sport="Breakdancing", Type="Indoor", FlagPath="/Flags/cyprus.png"},
            new OlympicEntry { Country="Russia", Game="Youth Olympic Games", Sport="Breakdancing", Type="Indoor", FlagPath="/Flags/russia.png"},
            new OlympicEntry { Country="Finland", Game="Youth Olympic Games", Sport="Skateboarding", Type="Outdoor", FlagPath="/Flags/finland.png"},
            new OlympicEntry { Country="Slovakia", Game="Youth Olympic Games", Sport="Skateboarding", Type="Outdoor", FlagPath="/Flags/slovakia.png"},
            new OlympicEntry { Country="Portugal", Game="Youth Olympic Games", Sport="Skateboarding", Type="Outdoor", FlagPath="/Flags/portugal.png"},
        };
    }
}
