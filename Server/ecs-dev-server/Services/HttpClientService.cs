using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ecs_dev_server.Services
{
    // This needs some sort of locking mechanism to ensure thread safety!!!

    // Use System.net.http.httpclient to receive and request
    public class HttpClientService: IHttpClient, IHttpClientAsync, IDisposable
    {
        public void Dispose() { }

        // Using Singleton Pattern improves the performance because only one connection is needed
        // but we can still implement interfaces.

        private static HttpClientService instance;

        private HttpClientService() { }

        public static HttpClientService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HttpClientService();
                }
                return instance;
            }
        }

        public HttpResponseMessage Get(string url)
        {
            // Appends the end of the BaseAddress with the parameter.
            var responseTask = instance.GetAsync(url);
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return result;
            }
            else
            {
                // Go into some error handling for the code.

                // THIS NEEDS MORE WORK
                return new HttpResponseMessage(result.StatusCode);

            }
        }

        public HttpResponseMessage PostAsJson(string url, string jsonString)
        {
            // Format obj into HttpContent
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            // Required additional package: System.Net.Http.Formatting.Extension
            var postTask = instance.PostAsJsonAsync(url, content);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                // Successful Post
                return result;

                // Do stuff with the resulting dataObject
            }
            else
            {
                // Go into some error handling for the Post error.

                // THIS NEEDS MORE WORK!!
                return new HttpResponseMessage(result.StatusCode);
            }
        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await instance.GetAsync(url);
        }

        public async Task<HttpResponseMessage> PostAsJsonAsync(string url, HttpContent content)
        {
            return await instance.PostAsJsonAsync(url, content);
        }

        
        
    }
}