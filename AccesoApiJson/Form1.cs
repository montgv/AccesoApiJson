using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace AccesoApiJson
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async Task llamadaAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://matchilling-chuck-norris-jokes-v1.p.rapidapi.com/jokes/random"),
                Headers =
    {
        { "accept", "application/json" },
        { "X-RapidAPI-Key", "44a2080887msh6c8641bbcc8aefdp10c17ejsnc2d3b9b61002" },
        { "X-RapidAPI-Host", "matchilling-chuck-norris-jokes-v1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                rtbInformacion.Text = body;
                //Console.WriteLine(body);
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await llamadaAsync();
        }
    }
}
