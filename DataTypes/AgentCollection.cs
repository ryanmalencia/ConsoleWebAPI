using System.Collections.Generic;

namespace DataTypes
{
    public class AgentCollection
    {
        public List<Agent> machines;

        /// <summary>
        /// Default constructor
        /// </summary>
        public AgentCollection()
        {
            machines = new List<Agent>();
        }

        /// <summary>
        /// Add agent to collection
        /// </summary>
        /// <param name="agent">Agent object</param>
        public void AddMachine(Agent agent)
        {
            machines.Add(agent);
        }
    }
}
