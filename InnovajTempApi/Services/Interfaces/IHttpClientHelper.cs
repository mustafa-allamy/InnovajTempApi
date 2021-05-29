using System.Net.Http;
using System.Threading.Tasks;

namespace InnovajTempApi.Services.Interfaces
{
    public interface IHttpClientHelper
    {
        Task<HttpResponseMessage> Get(string method, string baseUrl);
        Task<HttpResponseMessage> Post(string method, string body, string baseUrl);
    }
}