using System.Net;
using Newtonsoft.Json;

namespace WebAPIClient
{
    public class WebAPIClient
    {
#if DEBUG
        static string api_string = "http://10.0.0.57:59939/";
#else
        static string api_string = "http://10.0.0.57/";
#endif

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

        public static string SendAndGetResponseJson(string http, object theobject, string method)
        {
            string returnstring = "";

            return returnstring;
        }
    }
}