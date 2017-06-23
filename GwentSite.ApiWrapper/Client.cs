using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GwentSite.ApiWrapper.Models;
using GwentSite.ApiWrapper.Requests;
using System.Net.Http;

namespace GwentSite.ApiWrapper
{
    public class Client
    {
        private const string baseApi = "https://api.gwentapi.com/v0";
        private const string pageOfCardsEndpoint = "/cards";
        private const string variationEndpoint = "/variations";
        private static System.Net.Http.HttpClient _client = new System.Net.Http.HttpClient();

        public async Task<IPageOfCardData> GetPageOfCards(GetPageOfCardsRequest request)
        {
            HttpResponseMessage reply = await _client.GetAsync(baseApi + pageOfCardsEndpoint);
            string jsonReply = await reply.Content.ReadAsStringAsync();
            return new PageOfCardData(jsonReply);
        }
    }
}
