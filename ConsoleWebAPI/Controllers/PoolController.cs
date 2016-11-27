using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using DBInteraction;

namespace ConsoleWebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class PoolController : ApiController
    {
        [Route("api/pool/getallpools")]
        [HttpGet]
        public IHttpActionResult GetAllPools()
        {
            //string temp = JsonConvert.SerializeObject(AgentInteraction.Get());
            return Ok(JsonConvert.SerializeObject(PoolInteraction.Get()));
        }
    }
}
