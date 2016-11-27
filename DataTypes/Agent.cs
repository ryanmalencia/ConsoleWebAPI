namespace DataTypes
{
    public class Agent
    {
        public string Name { get; set; }
        public string Pool { get; set; }
        public string OS { get; set; }
        public string IP { get; set; }
        public int Sent_Job { get; set; }
        public int Running_Job { get; set; }
        public int Is_Dead { get; set; }

        /// <summary>
        /// Constructor for machine
        /// </summary>
        /// <param name="name">Machine Name</param>
        /// <param name="pool">Machine Pool</param>
        /// <param name="os">Machine OS</param>
        public Agent(string name, string pool = "Default", string os = "Unknown", string ip = "")
        {
            Name = name;
            Pool = pool;
            OS = os;
            IP = ip;
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
