using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace ecs_dev_server.Services
{
    interface IHttpClient
    {
        // ConsumeGet(): convert incoming requests into usable objects.
            // Grab the SSORequest Body and change convert the JSON.
            // JsonConverterService.DeserializeObject(x);

        void Get(String uriExtension);

        // ConsumePost(): convert incoming requests into usable objects.
            // Grab the SSORequest Body and change convert the JSON.
            // JsonConverterService.DeserializeObject(x);

        void Post<T>(String uriExtension, T obj);
    }
}
