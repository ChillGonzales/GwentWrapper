using Newtonsoft.Json;

namespace GwentApiWrapper
{
    [JsonArrayAttribute]
    public class Variation
    {
        public string Availability { get; set; }
        public string Href { get; set; }
        public Rarity Rarity { get; set; }
    }
}