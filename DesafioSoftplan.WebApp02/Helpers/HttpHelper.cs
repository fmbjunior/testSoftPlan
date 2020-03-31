using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace DesafioSoftplan.WebApp02.Helpers
{
    public class HttpHelper
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        public static HttpResponseMessage GetHttpResponse(string urlRequest)
        {
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return _httpClient.GetAsync(urlRequest).Result;
        }

        public static dynamic GetResult(string urlRequest)
        {
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = _httpClient.GetAsync(urlRequest).Result;

            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result;
            }

            return null;
        }
    }
}
