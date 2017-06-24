using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwentSite.ApiWrapper.Models
{
    public interface IVariationDetail
    {
        ImageHref Art { get; set; }
        string Availability { get; set; }
        ArtLevel Craft { get; set; }
        string Href { get; set; }
        ArtLevel Mill { get; set; }
        BasicInfo Rarity { get; set; }
        string UUID { get; set; }
    }
}
