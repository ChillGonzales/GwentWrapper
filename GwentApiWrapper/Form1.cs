﻿using System;
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
            var client = new HttpClient();
            System.IO.Stream returnStream = await client.GetStreamAsync(baseApi + cardEndpoint);
            List<byte[]> bufferList = new List<byte[]>();
            byte[] buffer = new byte[10000];
            returnStream.Read(buffer, 0, 10000);
            string str = "";
            str += System.Text.Encoding.Default.GetString(buffer);
            MessageBox.Show(str);
            var gwentReply = Newtonsoft.Json.JsonConvert.DeserializeObject<GwentReply>(str);
            foreach (var card in gwentReply.Results)
            {
                //Get card data
                HttpResponseMessage response = await client.GetAsync(card.Href);
                var stringData = await response.Content.ReadAsStringAsync();
                MessageBox.Show(stringData);

                //Get variation data for artwork
                var gwentCardData = Newtonsoft.Json.JsonConvert.DeserializeObject<GwentCardData>(stringData);
                HttpResponseMessage cardResponse = await client.GetAsync(baseApi + cardEndpoint + $"/{gwentCardData.UUID}" + $"/variations");
                var cardStringData = await cardResponse.Content.ReadAsStringAsync();
                MessageBox.Show(cardStringData);

                this.Invoke(new Action(() =>
                {
                    //pictureBox2.Image = bmp;
                }));
            }
        }
    }
}
