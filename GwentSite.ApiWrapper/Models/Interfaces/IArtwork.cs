using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwentSite.ApiWrapper.Models
{
    public interface IArtwork
    {
        string Name { get; set; }
        Bitmap Image { get; set; }
    }
}
