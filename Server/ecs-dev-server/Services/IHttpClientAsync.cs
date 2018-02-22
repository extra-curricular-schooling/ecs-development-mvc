using System.Net.Http;
using System.Threading.Tasks;

namespace ecs_dev_server.Services
{
    interface IHttpClientAsync
    {
        Task<HttpResponseMessage> GetAsync(string url);
        Task<HttpResponseMessage> PostAsJsonAsync(string url, HttpContent content);
    }
}
