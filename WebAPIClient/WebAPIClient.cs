using System.Net;
using Newtonsoft.Json;

namespace WebAPIClient
{
    public class WebAPIClient
    {
        /// <summary>
        /// the base string for connecting to the WebAPI
        /// </summary>
        static string api_string = "http://ryanlaptop:8080/";
        /// <summary>
        /// Get object from the DB
        /// </summary>
        /// <param name="http">HTTP request string</param>
        /// <param name="theobject">Object to send if needed (can be null)</param>
        /// <param name="method">The request type</param>
        /// <returns>Requested Object</returns>
        public static string GetResponseJson(string http, object theobject, string method)
        {
            string returnstring = "";

            using (var request = new WebClient())
            {
                if(theobject != null)
                {
                    string json = JsonConvert.SerializeObject(theobject);
                    returnstring = JsonConvert.DeserializeObject<string>(request.DownloadString(api_string + http + "/" + json));
                }
                else
                {
                    returnstring = JsonConvert.DeserializeObject<string>(request.DownloadString(api_string + http));
                }
            }
            return returnstring;
        }
        /// <summary>
        /// Put DB Interaction
        /// </summary>
        /// <param name="http">HTTP request string</param>
        /// <param name="theobject">Object to send if needed (can be null)</param>
        /// <param name="method">The request type</param>
        public static void SendResponseJson(string http, object theobject, string method)
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("content-type", "application/json");
                if (theobject != null)
                    client.UploadString(api_string + http, method, JsonConvert.SerializeObject(theobject));
                else
                    client.UploadString(api_string + http, "PUT", "");
            }
        }
        /// <summary>
        /// Simultaneous Put and Get DB Interaction
        /// </summary>
        /// <param name="http">HTTP request string</param>
        /// <param name="theobject">Object to send if needed (can be null)</param>
        /// <param name="method">The request type</param>
        /// <returns>Requested Object</returns>
        public static string SendAndGetResponseJson(string http, object theobject, string method)
        {
            string returnstring = "";

            return returnstring;
        }
    }
}