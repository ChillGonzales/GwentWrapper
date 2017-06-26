using GwentSite.ApiWrapper.Models;
using System.Collections.Generic;

namespace GwentSite.ApiWrapper
{
    public class GetArtworkListRequest
    {
        public List<BasicInfo> CardHrefs { get; set; }
    }
}