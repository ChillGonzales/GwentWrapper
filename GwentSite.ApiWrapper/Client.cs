using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GwentSite.ApiWrapper.Models;
using GwentSite.ApiWrapper.Requests;
using System.Net.Http;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net;

namespace GwentSite.ApiWrapper
{
    public class Client : IClient
    {
        private const string baseApi = "https://api.gwentapi.com/v0";
        private const string pageOfCardsEndpoint = "/cards";
        private const string variationEndpoint = "/variations";
        private static System.Net.Http.HttpClient _client;

        //public Client(HttpClient client)
        //{
        //    _client = client;
        //    ServicePointManager.ServerCertificateValidationCallback = Validator;
        //}
        public Client()
        {
            _client = new HttpClient(new ModernHttpClient.NativeMessageHandler());
            ServicePointManager.ServerCertificateValidationCallback = Validator;
        }
        public async Task<IPageOfCardData> GetPageOfCards(GetPageOfCardsRequest request)
        {
            try
            {
                HttpResponseMessage reply = await _client.GetAsync(baseApi + pageOfCardsEndpoint + $"?limit={request.Count}&offset={request.Offset}");
                CheckStatusCode(reply);
                string jsonReply = await reply.Content.ReadAsStringAsync();
                IPageOfCardData page = Newtonsoft.Json.JsonConvert.DeserializeObject<PageOfCardData>(jsonReply);
                return page;
            }
            catch (Exception ex) { return null; }
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
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<VariationDetail>>(jsonReply)[0];
        }
        public async Task<IArtwork> GetArtwork(GetArtworkRequest request)
        {
            HttpResponseMessage reply = await _client.GetAsync(request.ImageHref);
            CheckStatusCode(reply);
            System.IO.Stream imgStream = await reply.Content.ReadAsStreamAsync();
            return new Artwork()
            {
                Image = new Bitmap(imgStream)
            };
        }
        public async Task<List<IArtwork>> GetArtworkList(GetArtworkListRequest request)
        {
            var retList = new List<IArtwork>();
            foreach (var cardInfo in request.CardHrefs)
            {
                var cardData = await this.GetCardData(new GetCardDataRequest()
                {
                    Href = cardInfo.Href
                });
                var varDetail = await this.GetVariationDetail(new GetVariationDetailRequest()
                {
                    UUID = cardData.UUID
                });
                var artwork = await this.GetArtwork(new GetArtworkRequest()
                {
                    ImageHref = varDetail.Art.ThumbnailImage
                });
                artwork.Name = cardInfo.Name;
                retList.Add(artwork);
            }
            return retList;
        }
        private void CheckStatusCode(HttpResponseMessage reply)
        {
            if (!reply.IsSuccessStatusCode)
            {
                throw new InvalidOperationException($"API request threw an error code of {reply.ReasonPhrase}");
            }
        }
        private static bool Validator(object sender, X509Certificate certificate, X509Chain chain,
                                      SslPolicyErrors sslPolicyErrors)
        {
            //TODO: Refactor this shit, don't just trust all endpoints
            return true;
        }
    }
}
