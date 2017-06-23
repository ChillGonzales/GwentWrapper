using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwentApiWrapper.Models
{
    public class VariationResponse
    {
        public Art Art { get; set; }
        public string Availability { get; set; }
        public ArtLevel Craft { get; set; }
        public string Href { get; set; }
        public ArtLevel Mill { get; set; }
        public Rarity Rarity { get; set; }
        public string UUID { get; set; }
    }
}
