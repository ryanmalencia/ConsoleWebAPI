using System;

namespace DataTypes
{
    public class Job : IComparable
    {
        public int JobID { get; set; }
        public string JobName { get; set; }
        public int pk_job { get; set; }
        public int Repeat { get; set; }
        public int Started { get; set; }
        public int Distributed { get; set; }
        public int Finished { get; set; }
        public int PrerunGroup { get; set; }
        public int RunGroup { get; set; }
        public int PostRunGroup { get; set; }
        public DateTime Last_Finished { get; set; }
        public DateTime Last_Distributed { get; set; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="jobname">Job Name</param>
        public Job(string jobname = "")
        {
            JobName = jobname;
        }

        /// <summary>
        /// Comparable method
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Job task = obj as Job;

            if (task != null)
            {
                return Last_Finished.CompareTo(task.Last_Finished);
            }
            else
            {
                return 1;
            }
        }
    }
}
