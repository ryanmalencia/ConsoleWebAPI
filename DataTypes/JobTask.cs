using System;

namespace DataTypes
{
    public class JobTask : IComparable
    {
        public int JobTaskID { get; set; }
        public int Step { get; set; }
        public int Group { get; set; }
        public string Type { get; set; }
        public string Info { get; set; }

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
                return Step.CompareTo(task.Step);
            }
            else
            {
                return 1;
            }
        }
    }
}
