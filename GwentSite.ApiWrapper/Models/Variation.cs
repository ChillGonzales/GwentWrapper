using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwentSite.ApiWrapper.Models
{
    public class Variation : IVariation
    {
        public string Href { get; set; }

        public BasicInfo Rarity { get; set; }

        public string Availability { get; set; }
    }
}
