using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwentSite.ApiWrapper.Models
{
    public class Artwork : IArtwork
    {
        public string Name { get; set; }
        public Bitmap Image { get; set; }
    }
}
