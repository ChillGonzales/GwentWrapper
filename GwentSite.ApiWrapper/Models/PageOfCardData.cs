using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GwentSite.ApiWrapper.Models
{
    public class PageOfCardData : IPageOfCardData
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public List<BasicInfo> Results { get; set; }
    }
}
