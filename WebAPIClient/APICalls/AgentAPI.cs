using DataTypes;
using Newtonsoft.Json;

namespace WebAPIClient.APICalls
{
    public class AgentAPI
    {
        public static AgentCollection GetAllAgents()
        {
            string http = "api/machine/getallmachines";
            string method = "GET";
            string theobject = WebAPIClient.GetResponseJson(http, null, method);
            object collection = JsonConvert.DeserializeObject<AgentCollection>(theobject);
            return (AgentCollection)collection;
        }

        public static AgentCollection GetIdleAgents()
        {
            string http = "api/machine/getidleagents";
            string method = "GET";
            string theobject = WebAPIClient.GetResponseJson(http, null, method);
            object collection = JsonConvert.DeserializeObject<AgentCollection>(theobject);
            return (AgentCollection)collection;
        }

        public static Agent GetAgent(string name)
        {
            string http = "api/machine/getmachine/" + name;
            string method = "GET";
            string theobject = WebAPIClient.GetResponseJson(http, null, method);
            object agent = JsonConvert.DeserializeObject<Agent>(theobject);
            return (Agent)agent;
        }

        public static void GiveAgentJob(string name, int pk_job)
        {
            string http = "api/machine/givejob/" + name + "/" + pk_job;
            string method = "PUT";
            WebAPIClient.SendResponseJson(http, null, method);
        }

        public static void SetIdle(string name)
        {
            string http = "api/machine/setidle/" + name;
            string method = "PUT";
            WebAPIClient.SendResponseJson(http, null, method);
        }

        public static void SetQueued(string name)
        {
            string http = "api/machine/setqueued/" + name;
            string method = "PUT";
            WebAPIClient.SendResponseJson(http, null, method);
        }

        public static void SetDead(string name)
        {
            string http = "api/machine/setdead/" + name;
            string method = "PUT";
            WebAPIClient.SendResponseJson(http, null, method);
        }

        public static void AddAgent(Agent agent)
        {
            string http = "api/machine/add/";
            string method = "PUT";
            WebAPIClient.SendResponseJson(http, agent, method);
        }

        public static void UpdateIP(Agent agent)
        {
            string http = "api/machine/updateip";
            string method = "PUT";
            WebAPIClient.SendResponseJson(http, agent, method);
        }
    }
}
