using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using DBInteraction;

namespace ConsoleWebAPI.Controllers
{
    [EnableCors("*", "*", "*")]
    public class OSController : ApiController
    {
        [Route("api/os/getallos")]
        [HttpGet]
        public IHttpActionResult GetAllMachines()
        {
            return Ok(JsonConvert.SerializeObject(OSInteraction.Get()));
        }
    }
}
