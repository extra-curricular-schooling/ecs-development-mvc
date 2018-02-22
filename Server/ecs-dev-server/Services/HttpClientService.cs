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
        private HttpClient httpClient = new HttpClient();

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
            try
            {
                var responseTask = httpClient.GetAsync(url);
                responseTask.Wait();
                return responseTask.Result;
            }
            catch(Exception ex)
            {
                // Fix up the error handling
                Console.WriteLine(ex.Source + "\n" + ex.Message + "\n" + ex.StackTrace);
                return null;
            }
            
        }

        public HttpResponseMessage PostAsJson(string url, string jsonString)
        {
            try
            {
                // Format obj into HttpContent
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                // Required additional package: System.Net.Http.Formatting.Extension
                var postTask = httpClient.PostAsJsonAsync(url, content);
                postTask.Wait();

                // If successful, return the response.
                var response = postTask.Result;
                response.EnsureSuccessStatusCode();
                return response;
            }
            catch (Exception ex)
            {
                // Fix up the error handling
                Console.WriteLine(ex.Source + "\n" + ex.Message + "\n" + ex.StackTrace);
                return null;
            }
            
        }

        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await httpClient.GetAsync(url);
        }

        public async Task<HttpResponseMessage> PostAsJsonAsync(string url, HttpContent content)
        {
            return await httpClient.PostAsJsonAsync(url, content);
        }
    }
}