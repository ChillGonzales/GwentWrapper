using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwentSite.ApiWrapper.Requests
{
    public class GetPageOfCardsRequest
    {
        public int Count { get; set; }
        public int Offset { get; set; }
    }
}
