using MySql.Data.MySqlClient;
using DataTypes;
using System;

namespace DBInteraction
{
    public class PoolInteraction
    {
        /// <summary>
        /// Get pool pk based on name
        /// </summary>
        /// <param name="name">Name of pool</param>
        /// <returns>pk as int</returns>
        public static int Get(string name)
        {
            int pk = 0;
            MySqlConnection conn = new MySqlConnection(DBConstants.connstring);
            conn.Open();
            string sql = String.Format("SELECT pk_pool FROM pools where poolname = '{0}'", name);
            MySqlCommand comm = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                pk = rdr.GetInt32(rdr.GetOrdinal("pk_pool"));
            }
            conn.Close();

            return pk;
        }

        /// <summary>
        /// Get names of all the pools in the db
        /// </summary>
        /// <returns>PoolCollection containing all pools</returns>
        public static PoolCollection Get()
        {
            PoolCollection pools = new PoolCollection();

            MySqlConnection conn = new MySqlConnection(DBConstants.connstring);
            conn.Open();
            string sql = "SELECT poolname FROM pools";
            MySqlCommand comm = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                pools.AddPool(new Pool(rdr.GetString(rdr.GetOrdinal("poolname"))));
            }
            conn.Close();

            return pools;
        }
    }
}
