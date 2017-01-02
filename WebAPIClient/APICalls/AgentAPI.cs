using DataTypes;
using Newtonsoft.Json;

namespace WebAPIClient.APICalls
{
    public class AgentAPI
    {
        /// <summary>
        /// Get All Agents
        /// </summary>
        /// <returns>AgentCollection containing all Agents</returns>
        public static AgentCollection GetAllAgents()
        {
            string http = "api/agent/getallagents";
            string method = "GET";
            string theobject = WebAPIClient.GetResponseJson(http, null, method);
            object collection = JsonConvert.DeserializeObject<AgentCollection>(theobject);
            return (AgentCollection)collection;
        }
        /// <summary>
        /// Get Idle Agents
        /// </summary>
        /// <returns>AgentCollection containing idle Agents</returns>
        public static AgentCollection GetIdleAgents()
        {
            string http = "api/agent/getidleagents";
            string method = "GET";
            string theobject = WebAPIClient.GetResponseJson(http, null, method);
            object collection = JsonConvert.DeserializeObject<AgentCollection>(theobject);
            return (AgentCollection)collection;
        }
        /// <summary>
        /// Get Agent By Hostname
        /// </summary>
        /// <param name="name">Hostname of Agent</param>
        /// <returns>Agent with the specified hostname</returns>
        public static Agent GetAgent(string name)
        {
            string http = "api/agent/getagent/" + name;
            string method = "GET";
            string theobject = WebAPIClient.GetResponseJson(http, null, method);
            object agent = JsonConvert.DeserializeObject<Agent>(theobject);
            return (Agent)agent;
        }
        /// <summary>
        /// Set Agent to Running and give it a Job
        /// </summary>
        /// <param name="name">Hostname of Agent</param>
        /// <param name="pk_job">PK of Job</param>
        public static void GiveAgentJob(string name, int pk_job)
        {
            string http = "api/agent/givejob/" + name + "/" + pk_job;
            string method = "PUT";
            WebAPIClient.SendResponseJson(http, null, method);
        }
        /// <summary>
        /// Set Agent to Idle State
        /// </summary>
        /// <param name="name">Hostname of Agent</param>
        public static void SetIdle(string name)
        {
            string http = "api/agent/setidle/" + name;
            string method = "PUT";
            WebAPIClient.SendResponseJson(http, null, method);
        }
        /// <summary>
        /// Set Agent to Queued State
        /// </summary>
        /// <param name="name">Hostname of Agent</param>
        public static void SetQueued(string name)
        {
            string http = "api/agent/setqueued/" + name; 
            string method = "PUT";
            WebAPIClient.SendResponseJson(http, null, method);
        }
        /// <summary>
        /// Set Agent to Dead State
        /// </summary>
        /// <param name="name">Hostname of Agent</param>
        public static void SetDead(string name)
        {
            string http = "api/agent/setdead/" + name;
            string method = "PUT";
            WebAPIClient.SendResponseJson(http, null, method);
        }
        /// <summary>
        /// Add a New Agent
        /// </summary>
        /// <param name="agent">Agent to Add</param>
        public static void AddAgent(Agent agent)
        {
            string http = "api/agent/add/";
            string method = "PUT";
            WebAPIClient.SendResponseJson(http, agent, method);
        }
        /// <summary>
        /// Update an Agent
        /// </summary>
        /// <param name="agent">Agent to Update</param>
        public static void Update(Agent agent)
        {
            string http = "api/agent/update";
            string method = "PUT";
            WebAPIClient.SendResponseJson(http, agent, method);
        }
    }
}
