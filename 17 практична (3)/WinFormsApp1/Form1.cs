using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{

    public partial class Form1 : Form
    {
        private Timer timer;
        private string apiKey = "live_CNFrdlNvyBSxuyMTSSNB0PJSO2UFDlReWRCbrrLhYKhHKUQQjiIWsyS7BRkCbOhx"; // Замініть на ваш API ключ

        public Form1()
        {
            InitializeComponent();

            timer = new Timer();
            timer.Interval = 60000; // 1 хвилина
            timer.Tick += new EventHandler(Timer_Tick);
        }



        private void Timer_Tick(object sender, EventArgs e)
        {
            LoadImage();
        }

        private async void LoadImage()
        {
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "https://thedogapi.com/v1/images/random");
                request.Headers.Add("x-api-key", apiKey);

                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var imageURL = JsonConvert.DeserializeObject<ImageResponse>(json).message;

                    pictureBox1.ImageLocation = imageURL;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (timer.Enabled)
            {
                timer.Stop();
                button1.Text = "Запустити";
            }
            else
            {
                timer.Start();
                button1.Text = "Зупинити";
            }
        }
    }

    class ImageResponse
    {
        public string message { get; set; }
    }

}
