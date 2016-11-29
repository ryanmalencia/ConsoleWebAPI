using DataTypes;
using Newtonsoft.Json;

namespace WebAPIClient.APICalls
{
    public class JobTaskAPI
    {
        public static JobTaskCollection GetByGroup(int group)
        {
            string http = "api/jobtask/getbygroup/" + group;
            string method = "GET";
            string theobject = WebAPIClient.GetResponseJson(http, null, method);
            object collection = JsonConvert.DeserializeObject<JobTaskCollection>(theobject);
            return (JobTaskCollection)collection;
        }
    }
}
