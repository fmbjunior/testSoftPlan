using DesafioSoftplan.WebApp02;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace DesafioSoftplan.Test
{
    public class ApiTest
    {
        private const string urlApi = "http://localhost:61172/calculajuros";
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public ApiTest()
        {
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact(DisplayName = "TesteApiCalculaJuros")]
        public async Task TesteApi02()
        {
            double valorInicial = 100;
            double taxa = 0.01f;
            int meses = 5;
            string valorCalculado = CalcularTeste(valorInicial, taxa, meses);
            string url = urlApi + "?valorInicial=" + valorInicial + "&meses=" + meses;

            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var responseResult = await response.Content.ReadAsStringAsync();

            Assert.Equal(valorCalculado, responseResult);
        }

        private string CalcularTeste(double valorInicial, double taxa, int meses)
        {
            return string.Format("{0:0.00}", Math.Round((valorInicial * Math.Pow((1 + taxa), meses)), 2, MidpointRounding.ToNegativeInfinity));
        }
    }
}
