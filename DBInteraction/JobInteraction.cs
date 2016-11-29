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
        /// Get Job By Pk
        /// </summary>
        /// <returns>Job object</returns>
        public static Job GetJobByPk(int pk)
        {
            Job job = new Job();
            MySqlConnection conn = new MySqlConnection(DBConstants.connstring);
            conn.Open();
            string sql = "SELECT * FROM jobs WHERE pk_job = " + pk;
            MySqlCommand comm = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = comm.ExecuteReader();

            while (rdr.Read())
            {
                job.JobName = rdr.GetString(rdr.GetOrdinal("job_name"));
                job.pk_job = rdr.GetInt32(rdr.GetOrdinal("pk_job"));
                job.Repeat = rdr.GetInt32(rdr.GetOrdinal("repeat"));
                job.ExecutablePath = rdr.GetString(rdr.GetOrdinal("exe_path"));
                job.Finished = rdr.GetInt32(rdr.GetOrdinal("finished"));
                job.PrerunGroup = rdr.GetInt32(rdr.GetOrdinal("prerun_group"));
                job.RunGroup = rdr.GetInt32(rdr.GetOrdinal("run_group"));
                job.PostRunGroup = rdr.GetInt32(rdr.GetOrdinal("postrun_group"));
            }

            conn.Close();
            return job;
        }

        /// <summary>
        /// Set Job to Dist
        /// </summary>
        /// <param name="job">Job to distribute</param>
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
        /// Reset job status
        /// </summary>
        /// <param name="job">Job to reset</param>
        public static void PutReset(Job job)
        {
            MySqlConnection conn = new MySqlConnection(DBConstants.connstring);
            conn.Open();
            string sql = String.Format("UPDATE jobs set distributed = 0, finished = 0 WHERE pk_job = '{0}'", job.pk_job);
            MySqlCommand comm = new MySqlCommand(sql, conn);
            comm.ExecuteNonQuery();
            conn.Close();
        }

        /// <summary>
        /// Set Job to Finished
        /// </summary>
        /// <param name="job">Job to finish</param>
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
