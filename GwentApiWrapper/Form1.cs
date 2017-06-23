using System;
using System.Net.Http;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GwentApiWrapper.Models;

namespace GwentApiWrapper
{
    public partial class Form1 : Form
    {
        private const string baseApi = "https://api.gwentapi.com/v0";
        private const string cardEndpoint = "/cards";
        private const string variationEndpoint = "/variations";
        public Form1()
        {
            InitializeComponent();
            SetEventHandlers();
        }
        private void SetEventHandlers()
        {
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            //Pull in first 20 cards
            var client = new HttpClient();
            string str = await client.GetStringAsync(baseApi + cardEndpoint);
            var gwentReply = Newtonsoft.Json.JsonConvert.DeserializeObject<GwentReply>(str);

            foreach (var card in gwentReply.Results)
            {
                //Get card data
                HttpResponseMessage response = await client.GetAsync(card.Href);
                var stringData = await response.Content.ReadAsStringAsync();
                var gwentCardData = Newtonsoft.Json.JsonConvert.DeserializeObject<GwentCardData>(stringData);

                //Get variation data for artwork
                HttpResponseMessage variationData = await client.GetAsync(baseApi + cardEndpoint + $"/{gwentCardData.UUID}" + $"/variations");
                var variationStringData = await variationData.Content.ReadAsStringAsync();
                var variationObj = Newtonsoft.Json.JsonConvert.DeserializeObject<List<VariationResponse>>(variationStringData);

                //Get artwork image from variation data
                HttpResponseMessage imgResponse = await client.GetAsync(variationObj[0].Art.ThumbnailImage);
                System.IO.Stream imgStream = await imgResponse.Content.ReadAsStreamAsync();
                Image img = new Bitmap(imgStream);

                //Update UI
                this.Invoke(new Action(() =>
                {
                    lblName.Text = gwentCardData.Name;
                    lblFaction.Text = gwentCardData.Faction.Name;
                    lblFlavor.Text = gwentCardData.Flavor;
                    lblGroup.Text = gwentCardData.Group.Name;
                    pictureBox2.Image = img;
                }));
            }
        }
    }
}
