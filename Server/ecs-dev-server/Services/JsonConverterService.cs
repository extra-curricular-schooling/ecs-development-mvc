using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Runtime.Serialization.Json;
// Consider using ServiceStack.Text if the licensing allows. It looks cleaner.

namespace ecs_dev_server.Services
{
    /// <summary>
    /// Generic static service class to Serialize and Deserialize Json objects.
    /// </summary>
    public static class JsonConverterService
    {
        /// <summary>
        /// Accepts a generic object T to convert into a Json object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns>A stringified version of a Json object.</returns>
        public static string SerializeObject<T>(T obj)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream();
            ser.WriteObject(ms, obj);
            string jsonString = Encoding.UTF8.GetString(ms.ToArray());
            ms.Close();
            return jsonString;
        }

        /// <summary>
        /// Accepts a Json object and converts it into a generic object T.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString"></param>
        /// <returns>An object of type T</returns>
        public static T DeserializeObject<T>(string jsonString)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            T obj = (T)serializer.ReadObject(ms);
            return obj;
        }
    }



    // Unused Code because the Newtonsoft.Json.ConvertJson does not handle generics well.

    //public class UnusedJsonConverterService : IJsonConverter
    //{
    //    public T DeserializeObject<T>(String jsonStr)
    //    {
    //        return JsonConvert.DeserializeObject<T>(jsonStr);
    //    }


    //    public string SerializeObject<T>(T obj)
    //    {
    //        //return JsonConvert.SerializeObject<T>(obj);
    //        return "";
    //    }
    //}
}