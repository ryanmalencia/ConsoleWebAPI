using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using DBInteraction;
using DataTypes;

namespace ConsoleWebAPI.Controllers
{
    [EnableCors("*","*","*")]
    public class JobTaskController : ApiController
    {
        [Route("api/jobtask/getbygroup/{group}")]
        [HttpGet]
        public IHttpActionResult GetByGroup(int group)
        {
            return Ok(JsonConvert.SerializeObject(JobTaskInteraction.GetByGroup(group)));
        }
    }
}
