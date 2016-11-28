using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypes
{
    public class Job
    {
        public string JobName { get; set; }
        public int pk_job { get; set; }
        public string ExecutablePath { get; set; }
        public int Repeat { get; set; }
        public int Distributed { get; set; }
        public int Finished { get; set; }
        //Type type { get; set; }
        //enum Type { Backup, RunProgram}

        public Job(string jobname = "")
        {
            JobName = jobname;
        }
    }
}
