using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwentApiWrapper
{
    public class GwentCard
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
        public Variation Variations { get; set; }
        public string GetDisplayString {
            get
            {
                return $"Name: {Name}\n" + 
                       $"Category: {Categories}\n" +
                       $"Faction: {Faction.Name}\n" + 
                       $"Flavor: {Flavor}\n" + 
                       $"Group: {Group.Name}\n" + 
                       $"Info: {Info}\n" + 
                       $"Strength: {Strength.ToString()}\n" + 
                       $"Rarity: {Variations.Rarity}";
            }
        }
    }
}
