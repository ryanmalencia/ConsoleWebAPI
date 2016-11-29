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
        public int PrerunGroup { get; set; }
        public int RunGroup { get; set; }
        public int PostRunGroup { get; set; }
        //Type type { get; set; }
        //enum Type { Backup, RunProgram}

        public Job(string jobname = "")
        {
            JobName = jobname;
        }
    }
}
