using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using InnovajTempApi.Services.Interfaces;

namespace InnovajTempApi.Services
{
    public class HttpClientHelper : IHttpClientHelper
    {
        private readonly IHttpClientFactory _clientFactory;

        public HttpClientHelper(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<HttpResponseMessage> Get(string method, string baseUrl)
        {
            HttpClient httpClient = _clientFactory.CreateClient();
            httpClient.BaseAddress = new Uri(baseUrl);
            return await httpClient.GetAsync($"/{method}");
        }

        public async Task<HttpResponseMessage> Post(string method, string body, string baseUrl)
        {
            HttpClient httpClient = _clientFactory.CreateClient();
            httpClient.BaseAddress = new Uri(baseUrl);
            return await httpClient.PostAsync($"/{method}",
                new StringContent(body, Encoding.UTF8, "application/json"));
        }

       
    }
}