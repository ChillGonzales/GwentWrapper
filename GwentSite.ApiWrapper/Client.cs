using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GwentSite.ApiWrapper.Models;
using GwentSite.ApiWrapper.Requests;
using System.Net.Http;
using System.Drawing;

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
            HttpResponseMessage reply = await _client.GetAsync(baseApi + pageOfCardsEndpoint + $"?limit={request.Count}&offset={request.Offset}");
            CheckStatusCode(reply);
            string jsonReply = await reply.Content.ReadAsStringAsync();
            IPageOfCardData page = Newtonsoft.Json.JsonConvert.DeserializeObject<PageOfCardData>(jsonReply);
            return page;
        }
        public async Task<ICardData> GetCardData(GetCardDataRequest request)
        {
            HttpResponseMessage reply = await _client.GetAsync(request.Href);
            CheckStatusCode(reply);
            string jsonReply = await reply.Content.ReadAsStringAsync();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<CardData>(jsonReply);
        }
        public async Task<IVariationDetail> GetVariationDetail(GetVariationDetailRequest request)
        {
            HttpResponseMessage reply = await _client.GetAsync(baseApi + pageOfCardsEndpoint + $"/{request.UUID}" + variationEndpoint);
            CheckStatusCode(reply);
            string jsonReply = await reply.Content.ReadAsStringAsync();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<VariationDetail>(jsonReply);
        }
        public async Task<IArtwork> GetArtwork(GetArtworkRequest request)
        {
            HttpResponseMessage reply = await _client.GetAsync(request.ImageHref);
            CheckStatusCode(reply);
            System.IO.Stream imgStream = await reply.Content.ReadAsStreamAsync();
            return new Artwork()
            {
                ImageStream = imgStream
            };
        }
        private void CheckStatusCode(HttpResponseMessage reply)
        {
            if (!reply.IsSuccessStatusCode)
            {
                throw new InvalidOperationException($"API request threw an error code of {reply.ReasonPhrase}");
            }
        }
    }
}
