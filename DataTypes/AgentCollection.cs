using System.Collections.Generic;

namespace DataTypes
{
    public class AgentCollection
    {
        public List<Agent> Agents;

        /// <summary>
        /// Default constructor
        /// </summary>
        public AgentCollection()
        {
            Agents = new List<Agent>();
        }

        /// <summary>
        /// Add agent to collection
        /// </summary>
        /// <param name="agent">Agent object</param>
        public void AddAgent(Agent agent)
        {
            Agents.Add(agent);
        }
    }
}
