using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;
using System;

namespace GwentSite.AndroidUI
{
    [Activity(Label = "Gwent Deck Builder", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            Button btnGetCards = FindViewById<Button>(Resource.Id.btnLoadCards);
            var gridView = FindViewById<GridView>(Resource.Id.gridView1);
            var imgAdapter = new ImageAdapter(this);
            var apiClient = ApiFactory.GetInstance();
            List<System.IO.Stream> streams = new List<System.IO.Stream>();
            var pages = await apiClient.GetPageOfCards(new ApiWrapper.Requests.GetPageOfCardsRequest()
            {
                Count = 40,
                Offset = 0
            });
            foreach (var card in pages.Results)
            {
                var cardData = await apiClient.GetCardData(new ApiWrapper.Requests.GetCardDataRequest()
                {
                    Href = card.Href
                });
                var varData = await apiClient.GetVariationDetail(new ApiWrapper.Requests.GetVariationDetailRequest()
                {
                    UUID = cardData.UUID
                });
                var artwork = await apiClient.GetArtwork(new ApiWrapper.Requests.GetArtworkRequest()
                {
                    ImageHref = varData.Art.ThumbnailImage
                });
                streams.Add(artwork.ImageStream);
            }
            imgAdapter.LoadImages(streams);
            gridView.Adapter = imgAdapter;
        }
    }
}

