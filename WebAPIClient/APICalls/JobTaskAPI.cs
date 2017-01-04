using DataTypes;
using Newtonsoft.Json;

namespace WebAPIClient.APICalls
{
    public class JobTaskAPI
    {
        /// <summary>
        /// Get all Job Tasks by Group Number
        /// </summary>
        /// <param name="group">Group Number</param>
        /// <returns>Collection of all Job Tasks in the specified Group</returns>
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
