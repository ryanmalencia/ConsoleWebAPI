using MySql.Data.MySqlClient;
using DataTypes;

namespace DBInteraction
{
    public class OSInteraction
    {
        /// <summary>
        /// Get PK of pool based on name
        /// </summary>
        /// <param name="name">Pool name</param>
        /// <returns>Pool pk</returns>
        public static int GetPK(string name)
        {
            int pk = 0;

            MySqlConnection conn = new MySqlConnection(DBConstants.connstring);
            conn.Open();
            string sql = "SELECT pk_os FROM os WHERE os_name = '" + name + "';";
            MySqlCommand comm = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                pk = rdr.GetInt32(rdr.GetOrdinal("pk_os"));
            }
            conn.Close();

            return pk;
        }

        /// <summary>
        /// Get all oses
        /// </summary>
        /// <returns>OSCollection with all os objects</returns>
        public static OSCollection Get()
        {
            OSCollection oses = new OSCollection();

            MySqlConnection conn = new MySqlConnection(DBConstants.connstring);
            conn.Open();
            string sql = "SELECT os_name FROM os;";
            MySqlCommand comm = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                oses.AddOS(new OS(rdr.GetString(rdr.GetOrdinal("os_name"))));
            }
            conn.Close();

            return oses;
        }
    }
}
