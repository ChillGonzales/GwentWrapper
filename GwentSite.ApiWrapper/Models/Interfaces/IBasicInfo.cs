using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwentSite.ApiWrapper.Models
{
    public interface IBasicInfo
    {
        string Href { get; set; }
        string Name { get; set; }
    }
}
