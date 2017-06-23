using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwentSite.ApiWrapper.Models
{
    public interface ICardData
    {
        List<BasicInfo> Categories { get; set; }
        BasicInfo Faction { get; set; }
        string Flavor { get; set; }
        BasicInfo Group { get; set; }
        string Href { get; set; }
        string Info { get; set; }
        string Name { get; set; }
        string[] Positions { get; set; }
        int Strength { get; set; }
        string UUID { get; set; }
        List<Variation> Variations { get; set; }
    }
}
