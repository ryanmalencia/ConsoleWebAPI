using DataTypes;
using Newtonsoft.Json;

namespace WebAPIClient.APICalls
{
    public class AgentAPI
    {
        public static AgentCollection GetAllAgents()
        {
            string http = "api/agent/getallagents";
            string method = "GET";
            string theobject = WebAPIClient.GetResponseJson(http, null, method);
            object collection = JsonConvert.DeserializeObject<AgentCollection>(theobject);
            return (AgentCollection)collection;
        }

        public static AgentCollection GetIdleAgents()
        {
            string http = "api/agent/getidleagents";
            string method = "GET";
            string theobject = WebAPIClient.GetResponseJson(http, null, method);
            object collection = JsonConvert.DeserializeObject<AgentCollection>(theobject);
            return (AgentCollection)collection;
        }

        public static Agent GetAgent(string name)
        {
            string http = "api/agent/getagent/" + name;
            string method = "GET";
            string theobject = WebAPIClient.GetResponseJson(http, null, method);
            object agent = JsonConvert.DeserializeObject<Agent>(theobject);
            return (Agent)agent;
        }

        public static void GiveAgentJob(string name, int pk_job)
        {
            string http = "api/agent/givejob/" + name + "/" + pk_job;
            string method = "PUT";
            WebAPIClient.SendResponseJson(http, null, method);
        }

        public static void SetIdle(string name)
        {
            string http = "api/agent/setidle/" + name;
            string method = "PUT";
            WebAPIClient.SendResponseJson(http, null, method);
        }

        public static void SetQueued(string name)
        {
            string http = "api/agent/setqueued/" + name;
            string method = "PUT";
            WebAPIClient.SendResponseJson(http, null, method);
        }

        public static void SetDead(string name)
        {
            string http = "api/agent/setdead/" + name;
            string method = "PUT";
            WebAPIClient.SendResponseJson(http, null, method);
        }

        public static void AddAgent(Agent agent)
        {
            string http = "api/agent/add/";
            string method = "PUT";
            WebAPIClient.SendResponseJson(http, agent, method);
        }

        public static void UpdateIP(Agent agent)
        {
            string http = "api/agent/updateip";
            string method = "PUT";
            WebAPIClient.SendResponseJson(http, agent, method);
        }
    }
}
