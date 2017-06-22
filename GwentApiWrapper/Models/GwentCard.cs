using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwentApiWrapper.Models
{
    public class GwentCard
    {
        public GwentCardData CardData { get; private set; }
        public Category Category { get; private set; }
        public Variation Variations { get; private set; }

        public GwentCard(GwentCardData data)
        {
            CardData = data;
            Category = new Category();
            foreach (var item in CardData.Categories)
            {
                if (item.Key == "href")
                {
                    Category.Href = item.Value;
                }
                else if (item.Key == "name")
                {
                    Category.Name = item.Value;
                }
            }
            Variations = new Variation();
            foreach (var item in CardData.Variations)
            {
                if (item.Key == "href")
                {
                    Variations.Href = item.Value;
                }
                else if (item.Key == "availability")
                {
                    Variations.Availability = item.Value;
                }
                else if (item.Key == "rarity")
                {
                    Variations.Rarity = new Rarity() { Href = item.Value };
                }
            }
        }
        public string GetDisplayString
        {
            get
            {
                return $"Name: {CardData.Name}\n" +
                       $"Category: {Category.Name}\n" +
                       $"Faction: {CardData.Faction.Name}\n" +
                       $"Flavor: {CardData.Flavor}\n" +
                       $"Group: {CardData.Group.Name}\n" +
                       $"Info: {CardData.Info}\n" +
                       $"Strength: {CardData.Strength.ToString()}\n";
                       //$"Rarity: {}";
            }
        }
    }
}
