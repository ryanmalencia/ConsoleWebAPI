using DataTypes;
using Newtonsoft.Json;

namespace WebAPIClient.APICalls
{
    public class JobAPI
    {
        /// <summary>
        /// Get All Jobs
        /// </summary>
        /// <returns>Collection Containing all Jobs</returns>
        public static JobCollection GetAllJobs()
        {
            string http = "api/job/getalljobs";
            string method = "GET";
            string theobject = WebAPIClient.GetResponseJson(http, null, method);
            object collection = JsonConvert.DeserializeObject<JobCollection>(theobject);
            return (JobCollection)collection;
        }
        /// <summary>
        /// Get a Job By its ID
        /// </summary>
        /// <param name="id">ID of Job</param>
        /// <returns>Desired Job, or null if it does not exist</returns>
        public static Job GetById(int id)
        {
            string http = "api/job/getbyid/" + id;
            string method = "GET";
            string theobject = WebAPIClient.GetResponseJson(http, null, method);
            object job = JsonConvert.DeserializeObject<Job>(theobject);
            return (Job)job;
        }
        /// <summary>
        /// Set a Job to a Distributed State
        /// </summary>
        /// <param name="job">Job to Set</param>
        public static void SetJobDist(Job job)
        {
            string http = "api/job/setdist/";
            string method = "PUT";
            WebAPIClient.SendResponseJson(http, job, method);
        }
        /// <summary>
        /// Set a Job to a Finished State
        /// </summary>
        /// <param name="job">Job to Set</param>
        public static void SetJobFinished(Job job)
        {
            string http = "api/job/setfinished/";
            string method = "PUT";
            WebAPIClient.SendResponseJson(http, job, method);
        }
        /// <summary>
        /// Set a Job to a Started State
        /// </summary>
        /// <param name="job">Job to Set</param>
        public static void SetJobStarted(Job job)
        {
            string http = "api/job/setstarted/";
            string method = "PUT";
            WebAPIClient.SendResponseJson(http, job, method);
        }
        /// <summary>
        /// Reset a Job (so it will be rerun again)
        /// </summary>
        /// <param name="job">Job to Reset</param>
        public static void ResetJob(Job job)
        {
            string http = "api/job/reset/";
            string method = "PUT";
            WebAPIClient.SendResponseJson(http, job, method);
        }
    }
}
