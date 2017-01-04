namespace DataTypes
{
    public class Agent
    {
        public int AgentID { get; set; }
        public string Name { get; set; }
        public int Pool { get; set; }
        public int OS { get; set; }
        public string IP { get; set; }
        public int Sent_Job { get; set; }
        public int Running_Job { get; set; }
        public int Is_Dead { get; set; }
        public int fk_job { get; set; }

        /// <summary>
        /// Constructor for machine
        /// </summary>
        /// <param name="name">Machine Name</param>
        /// <param name="pool">Machine Pool</param>
        /// <param name="os">Machine OS</param>
        /// <param name="ip">Machine IP</param>
        public Agent(string name, int pool = 1, int os = 1, string ip = "")
        {
            Name = name;
            Pool = pool;
            OS = os;
            IP = ip;
        }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public Agent()
        {

        }

        /// <summary>
        /// Gets if agent is idle
        /// </summary>
        /// <returns>True if idle, false if not</returns>
        public bool IsIdle()
        {
            if (IsDead())
            {
                return false;
            }
            else
            {
                if (Sent_Job == 0 && Running_Job == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Gets if agent is dead
        /// </summary>
        /// <returns>True if dead, false if not</returns>
        public bool IsDead()
        {
            if(Is_Dead == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
