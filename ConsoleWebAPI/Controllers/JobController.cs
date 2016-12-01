using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using DBInteraction;
using DataTypes;

namespace ConsoleWebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class JobController : ApiController
    {
        [Route("api/job/getalljobs")]
        [HttpGet]
        public IHttpActionResult GetAllJobs()
        {
            return Ok(JsonConvert.SerializeObject(JobInteraction.Get()));
        }

        [Route("api/job/getbypk/{pk}")]
        [HttpGet]
        public IHttpActionResult GetJobByPk(int pk)
        {
            return Ok(JsonConvert.SerializeObject(JobInteraction.GetJobByPk(pk)));
        }

        [Route("api/job/setdist")]
        [HttpPut]
        public void PutDist(Job job)
        {
            JobInteraction.PutDist(job);
        }

        [Route("api/job/setstarted")]
        [HttpPut]
        public void PutStarted(Job job)
        {
            JobInteraction.PutStarted(job);
        }

        [Route("api/job/setfinished")]
        [HttpPut]
        public void PutFinished(Job job)
        {
            JobInteraction.PutFinished(job);
        }

        [Route("api/job/reset")]
        [HttpPut]
        public void PutReset(Job job)
        {
            JobInteraction.PutReset(job);
        }
    }
}
