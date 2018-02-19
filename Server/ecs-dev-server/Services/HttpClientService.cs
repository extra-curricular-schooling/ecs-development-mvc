using System;
using System.Net.Http;

namespace ecs_dev_server.Services
{
    // Use System.net.http.httpclient to receive and request
    public class HttpClientService : IHttpClient, IDisposable
    {
        public void Dispose() {}

        private HttpClient client;
        public HttpClientService(String uri)
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(uri)
            };
        }

        //HTTP GET
        public void Get(String uriExtension)
        {
            // Appends the end of the BaseAddress with the parameter.
            var responseTask = client.GetAsync(uriExtension);
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                // Do some stuff with it.
                // return result;
                
            }
            else
            {
                // Go into some error handling for the code.
            }
        }

        //HTTP POST
        public void Post<T>(String uriExtension, T obj)
        {
            
            // Required additional package: System.Net.Http.Formatting.Extension
            var postTask = client.PostAsJsonAsync(uriExtension, obj);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsAsync<T>();
                readTask.Wait();

                var dataObject = readTask.Result;

                // Do stuff with the resulting dataObject
            }
            else
            {
                // Go into some error handling for the Post error.
            }
            
        }
        
    }
}