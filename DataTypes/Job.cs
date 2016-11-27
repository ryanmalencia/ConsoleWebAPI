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
        Type type { get; set; }
        enum Type { Backup, RunProgram}

        public Job(string jobname = "")
        {
            JobName = jobname;
        }
    }
}
