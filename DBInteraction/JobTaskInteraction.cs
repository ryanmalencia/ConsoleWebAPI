using DataTypes;
using MySql.Data.MySqlClient;

namespace DBInteraction
{
    public class JobTaskInteraction
    {
        /*
        /// <summary>
        /// Get JobTasks By Group Number
        /// </summary>
        /// <returns>Collection of JobTasks</returns>
        public static JobTaskCollection GetByGroup(int group)
        {
            JobTaskCollection collection = new JobTaskCollection();
            MySqlConnection conn = new MySqlConnection(DBConstants.connstring);
            conn.Open();
            string sql = "SELECT * FROM jobtasks WHERE jobtask_group = " + group;
            MySqlCommand comm = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = comm.ExecuteReader();

            while (rdr.Read())
            {
                JobTask task = new JobTask();
                task.step = rdr.GetInt32(rdr.GetOrdinal("step"));
                task.type = rdr.GetString(rdr.GetOrdinal("jobtask_type"));
                task.info = rdr.GetString(rdr.GetOrdinal("jobtask_info"));
                collection.AddJobTask(task);
            }

            conn.Close();
            return collection;
        }
        */
    }
}
