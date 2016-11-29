using System.Collections.Generic;

namespace DataTypes
{
    public class JobTaskCollection
    {
        public List<JobTask> Tasks;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public JobTaskCollection()
        {
            Tasks = new List<JobTask>();
        }

        /// <summary>
        /// Add JobTask to Collection
        /// </summary>
        /// <param name="task">JobTask to Add</param>
        public void AddJobTask(JobTask task)
        {
            Tasks.Add(task);
            Tasks.Sort();
        }
    }
}
