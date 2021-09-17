using System.Collections.Generic;

namespace TestTcgScanner.Models
{
    public class MtgCard
    {
        public string Name { get; set; }

        public string? Number { get; set; }

        public string Description { get; set; }

        public string? Id { get; set; }
        public List<string>? Names { get; set; }
        public string ManaCost { get; set; } = "";
        public double? Cmc { get; set; }
        public List<string>? Colors { get; set; }
        public List<string>? ColorIdentity { get; set; }
        public string Type { get; set; } = "";
        public List<string>? Supertypes { get; set; }
        public List<string> Types { get; set; }
        public List<string>? Subtypes { get; set; }
        public string Rarity { get; set; } = "";
        public string Set { get; set; } = "";
        public string SetName { get; set; } = "";
        public string? Text { get; set; }
        public string Artist { get; set; } = "";
        public string? Power { get; set; }
        public string? Toughness { get; set; }
        public string? Loyalty { get; set; }
        public int? Multiverseid { get; set; }
        public string? ImageUrl { get; set; }
        public string Layout { get; set; } = "";
        public List<MtgCardLegality>? Legalities { get; set; }
        public List<MtgCardRuling>? Rulings { get; set; }
        public List<MtgCardForeignName>? ForeignNames { get; set; }
    }
}
