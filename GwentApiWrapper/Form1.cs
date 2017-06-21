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

namespace GwentApiWrapper
{
    public partial class Form1 : Form
    {
        private const string baseApi = "https://api.gwentapi.com/v0";
        private const string cardEndpoint = "/cards";
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
                HttpResponseMessage response = await client.GetAsync(card.Href);
                var stringData = await response.Content.ReadAsStringAsync();
                var gwentCardData = Newtonsoft.Json.JsonConvert.DeserializeObject<GwentCard>(stringData);
                MessageBox.Show(gwentCardData.GetDisplayString);
                //System.IO.File.WriteAllBytes(@"C:\Users\Colin\Documents\img.jpeg", byteArray);
                //var bmp = new Bitmap(new System.IO.MemoryStream(byteArray));
                this.Invoke(new Action(() =>
                {
                    //pictureBox2.Image = bmp;
                }));
                MessageBox.Show($"{card.Name}\n{card.Href}");
            }
        }
    }
}
