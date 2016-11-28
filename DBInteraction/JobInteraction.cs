using System;
using DataTypes;
using MySql.Data.MySqlClient;

namespace DBInteraction
{
    public class JobInteraction
    {
        /// <summary>
        /// Get All Jobs
        /// </summary>
        /// <returns>JobCollection with all Jobs</returns>
        public static JobCollection Get()
        {
            JobCollection array = new JobCollection();
            MySqlConnection conn = new MySqlConnection(DBConstants.connstring);
            conn.Open();
            string sql = "SELECT * FROM jobs WHERE distributed = 0";
            MySqlCommand comm = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = comm.ExecuteReader();

            while (rdr.Read())
            {
                Job newjob = new Job();
                newjob.JobName = rdr.GetString(rdr.GetOrdinal("job_name"));
                newjob.pk_job = rdr.GetInt32(rdr.GetOrdinal("pk_job"));
                newjob.Repeat = rdr.GetInt32(rdr.GetOrdinal("repeat"));
                newjob.ExecutablePath = rdr.GetString(rdr.GetOrdinal("exe_path"));
                newjob.Finished = rdr.GetInt32(rdr.GetOrdinal("finished"));
                array.AddJob(newjob);
            }

            conn.Close();
            return array;
        }

        /// <summary>
        /// Set Job to Dist
        /// </summary>
        /// <param name="pk">pk of Job</param>
        public static void PutDist(Job job)
        {
            MySqlConnection conn = new MySqlConnection(DBConstants.connstring);
            conn.Open();
            string sql = String.Format("UPDATE jobs set distributed = 1, finished = 0 WHERE pk_job = '{0}'", job.pk_job);
            MySqlCommand comm = new MySqlCommand(sql, conn);
            comm.ExecuteNonQuery();
            conn.Close();
        }

        /// <summary>
        /// Set Job to Finished
        /// </summary>
        /// <param name="pk">pk of Job</param>
        public static void PutFinished(Job job)
        {
            MySqlConnection conn = new MySqlConnection(DBConstants.connstring);
            conn.Open();
            string sql = "";
            if (job.Repeat == 1)
                sql = String.Format("UPDATE jobs set distributed = 0, finished = 1 WHERE pk_job = '{0}'", job.pk_job);
            else
                sql = String.Format("UPDATE jobs set distributed = 1, finished = 1 WHERE pk_job = '{0}'", job.pk_job);
            MySqlCommand comm = new MySqlCommand(sql, conn);
            comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}
