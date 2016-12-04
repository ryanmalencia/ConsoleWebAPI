using System.Web.Http;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using DBInteraction;
using DataTypes;

namespace ConsoleWebAPI.Controllers
{
    [EnableCors("*","*","*")]
    public class MachineController : ApiController
    {
        [Route("api/machine/getallmachines")]
        [HttpGet]
        public IHttpActionResult GetAllMachines()
        {
            return Ok(JsonConvert.SerializeObject(AgentInteraction.Get()));
        }

        [Route("api/machine/getidleagents")]
        [HttpGet]
        public IHttpActionResult GetIdleMachines()
        {
            return Ok(JsonConvert.SerializeObject(AgentInteraction.GetIdleAgents()));
        }

        [Route("api/machine/getmachine/{name}")]
        [HttpGet]
        public IHttpActionResult GetOneMachine(string name)
        {
            return Ok(JsonConvert.SerializeObject(AgentInteraction.Get(name)));
        }

        [Route("api/machine/add/")]
        [HttpPut]
        public void Put(Agent agent)
        {
            AgentInteraction.Add(agent);
        }

        [Route("api/machine/givejob/{agent}/{pk_job}")]
        [HttpPut]
        public void PutRunning(string agent, int pk_job)
        {
            AgentInteraction.SetAgentRunning(agent, pk_job);
        }

        [Route("api/machine/setqueued/{agent}")]
        [HttpPut]
        public void PutQueued(string agent)
        {
            AgentInteraction.SetAgentQueued(agent);
        }

        [Route("api/machine/setidle/{agent}")]
        [HttpPut]
        public void PutIdle(string agent)
        {
            AgentInteraction.SetAgentIdle(agent);
        }

        [Route("api/machine/setdead/{agent}")]
        [HttpPut]
        public void PutDead(string agent)
        {
            AgentInteraction.SetAgentDead(agent);
        }

        [Route("api/machine/delete/{name}")]
        [HttpDelete]
        public void Delete(string name)
        {
            AgentInteraction.Delete(name);
        }

        [Route("api/machine/updateip/")]
        [HttpPut]
        public void PutIP(Agent agent)
        {
            AgentInteraction.UpdateIP(agent);
        }
    }
}
