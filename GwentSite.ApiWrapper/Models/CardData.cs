using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwentSite.ApiWrapper.Models
{
    public class CardData : ICardData
    {
        public List<BasicInfo> Categories { get; set; }
        public BasicInfo Faction { get; set; }
        public string Flavor { get; set; }
        public BasicInfo Group { get; set; }
        public string Href { get; set; }
        public string Info { get; set; }
        public string Name { get; set; }
        public string[] Positions { get; set; }
        public int Strength { get; set; }
        public string UUID { get; set; }
        public List<Variation> Variations { get; set; }
    }
}
