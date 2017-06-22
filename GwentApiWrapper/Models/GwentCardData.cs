using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwentApiWrapper
{
    public class GwentCardData
    {
        public List<KeyValuePair<string, string>> Categories { get; set; }
        public Faction Faction { get; set; }
        public string Flavor { get; set; }
        public Group Group { get; set; }
        public string Href { get; set; }
        public string Info { get; set; }
        public string Name { get; set; }
        public string[] Positions { get; set; }
        public int Strength { get; set; }
        public string UUID { get; set; }
        public List<KeyValuePair<string, string>> Variations { get; set; }
    }
}
