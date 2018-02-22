using System.Net.Http;

namespace ecs_dev_server.Services
{
    interface IHttpClient
    {
        HttpResponseMessage Get(string url);
        HttpResponseMessage PostAsJson(string url, string jsonString);
    }
}
