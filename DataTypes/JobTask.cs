using System;

namespace DataTypes
{
    public class JobTask : IComparable
    {
        public int step { get; set; }
        public string type { get; set; }
        public string info { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        public JobTask()
        {

        }

        /// <summary>
        /// Comparable method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            JobTask task = obj as JobTask;

            if(task != null)
            {
                return step.CompareTo(task.step);
            }
            else
            {
                return 1;
            }
        }
    }
}
