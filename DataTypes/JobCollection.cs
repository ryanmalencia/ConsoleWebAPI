using System.Collections.Generic;

namespace DataTypes
{
    public class JobCollection
    {
        public List<Job> Jobs;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public JobCollection()
        {
            Jobs = new List<Job>();
        }

        /// <summary>
        /// Add job to collection
        /// </summary>
        /// <param name="job">Job object to add</param>
        public void AddJob(Job job)
        {
            Jobs.Add(job);
        }
    }
}
