using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwentApiWrapper
{
    public class GwentReply
    {
        public string Count { get; set; }
        public string Next { get; set; }
        public List<GwentCardLink> Results { get; set; }
    }
}
