using GwentSite.ApiWrapper;
using GwentSite.ApiWrapper.Models;
using GwentSite.ApiWrapper.Requests;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GwentSite.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IClient _client;

        public HomeController(IClient client)
        {
            _client = client;
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> Cards()
        {
            IPageOfCardData page = await _client.GetPageOfCards(new ApiWrapper.Requests.GetPageOfCardsRequest()
            {
                Count = 10,
                Offset = 0
            });
            List<IVariationDetail> varDetails = new List<IVariationDetail>();
            foreach (var card in page.Results)
            {
                var cardData = await _client.GetCardData(new GetCardDataRequest()
                {
                    Href = card.Href
                });
                var varDetail = await _client.GetVariationDetail(new GetVariationDetailRequest()
                {
                    UUID = cardData.UUID
                });
                varDetails.Add(varDetail);
            }
            return View(varDetails);
        }
        public static string BmpToBase64(Bitmap image)
        {
            string base64Str = "";
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                byte[] imageBytes = ms.ToArray();
                base64Str = Convert.ToBase64String(imageBytes);
            }
            return base64Str;
        }
    }
}