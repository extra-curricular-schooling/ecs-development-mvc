using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
// Consider using ServiceStack.Text if the licensing allows. It looks cleaner.

namespace ecs_dev_server.Services
{
    /// <summary>
    /// Generic static service class to Serialize and Deserialize Json objects.
    /// </summary>
    public static class JsonConverterService
    {
        public static T DeserializeObject<T>(String json)
        {
            try
            {
                var obj = JsonConvert.DeserializeObject<T>(json);
                if (obj != null)
                {
                    return obj;
                }
                throw new NullReferenceException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Source + "\n" + ex.Message + "\n" + ex.StackTrace);

                // Returns regardless. Should figure out how to correct the deserialziation.
                return default(T);
            }
            
        }

        public static string SerializeObject<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}