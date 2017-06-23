using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwentSite.ApiWrapper.Models
{
    public class VariationDetail : IVariationDetail
    {
        public ImageHref Art { get; set; }
        public string Availability { get; set; }
        public ArtLevel Craft { get; set; }
        public string Href { get; set; }
        public ArtLevel Mill { get; set; }
        public BasicInfo Rarity { get; set; }
        public string UUID { get; set; }

    }
}
