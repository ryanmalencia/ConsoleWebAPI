using DataTypes;
using Newtonsoft.Json;

namespace WebAPIClient.APICalls
{
    public class JobAPI
    {
        public static JobCollection GetAllJobs()
        {
            string http = "api/job/getalljobs";
            string method = "GET";
            string theobject = WebAPIClient.GetResponseJson(http, null, method);
            object collection = JsonConvert.DeserializeObject<JobCollection>(theobject);
            return (JobCollection)collection;
        }

        public static void SetJobDist(Job job)
        {
            string http = "api/job/setdist/";
            string method = "PUT";
            WebAPIClient.SendResponseJson(http, job, method);
        }

        public static void SetJobFinished(Job job)
        {
            string http = "api/job/setfinished/";
            string method = "PUT";
            WebAPIClient.SendResponseJson(http, job, method);
        }
    }
}
