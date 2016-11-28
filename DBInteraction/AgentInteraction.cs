using System;
using DataTypes;
using MySql.Data.MySqlClient;

namespace DBInteraction
{
    public class AgentInteraction
    {
        /// <summary>
        /// Get All Agents
        /// </summary>
        /// <returns>Object Array of Agents</returns>
        public static AgentCollection Get()
        {
            AgentCollection array = new AgentCollection();
            MySqlConnection conn = new MySqlConnection(DBConstants.connstring);
            conn.Open();
            string sql = "SELECT agent_name, poolname, os_name, ip_address, running_job, sent_job,is_dead FROM agents join pools on fk_pool = pk_pool join os on fk_os = pk_os";
            MySqlCommand comm = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = comm.ExecuteReader();
            while(rdr.Read())
            {
                Agent newagent = new Agent(rdr.GetString(rdr.GetOrdinal("agent_name")), rdr.GetString(rdr.GetOrdinal("poolname")), rdr.GetString(rdr.GetOrdinal("os_name")), rdr.GetString(rdr.GetOrdinal("ip_address")));
                newagent.Running_Job = rdr.GetInt32(rdr.GetOrdinal("running_job"));
                newagent.Sent_Job = rdr.GetInt32(rdr.GetOrdinal("sent_job"));
                newagent.Is_Dead = rdr.GetInt32(rdr.GetOrdinal("is_dead"));
                array.AddMachine(newagent);
            }
            conn.Close();

            return array;
        }

        /// <summary>
        /// Get Idle Agents
        /// </summary>
        /// <returns>Object Array of Agents</returns>
        public static AgentCollection GetIdleAgents()
        {
            AgentCollection array = new AgentCollection();
            MySqlConnection conn = new MySqlConnection(DBConstants.connstring);
            conn.Open();
            string sql = "SELECT agent_name, poolname, os_name, ip_address, running_job, sent_job,is_dead FROM agents join pools on fk_pool = pk_pool join os on fk_os = pk_os WHERE running_job = 0 AND sent_job = 0 AND is_dead = 0";
            MySqlCommand comm = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                Agent newagent = new Agent(rdr.GetString(rdr.GetOrdinal("agent_name")), rdr.GetString(rdr.GetOrdinal("poolname")), rdr.GetString(rdr.GetOrdinal("os_name")), rdr.GetString(rdr.GetOrdinal("ip_address")));
                newagent.Running_Job = rdr.GetInt32(rdr.GetOrdinal("running_job"));
                newagent.Sent_Job = rdr.GetInt32(rdr.GetOrdinal("sent_job"));
                newagent.Is_Dead = rdr.GetInt32(rdr.GetOrdinal("is_dead"));
                array.AddMachine(newagent);
            }
            conn.Close();

            return array;
        }

        /// <summary>
        /// Get agent based on name
        /// </summary>
        /// <param name="name">Agent name</param>
        /// <returns>Agent object</returns>
        public static Agent Get(string name)
        {
            Agent agent = null;
            MySqlConnection conn = new MySqlConnection(DBConstants.connstring);
            conn.Open();
            string sql = String.Format("SELECT agent_name, poolname, os_name, ip_address, running_job, sent_job, is_dead  FROM agents join pools on fk_pool = pk_pool join os on fk_os = pk_os where agent_name = '{0}'", name);
            MySqlCommand comm = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = comm.ExecuteReader();
            while (rdr.Read())
            {
                agent = new Agent(rdr.GetString(rdr.GetOrdinal("agent_name")), rdr.GetString(rdr.GetOrdinal("poolname")), rdr.GetString(rdr.GetOrdinal("os_name")), rdr.GetString(rdr.GetOrdinal("ip_address")));
                agent.Is_Dead = rdr.GetInt32(rdr.GetOrdinal("is_dead"));
                agent.Running_Job = rdr.GetInt32(rdr.GetOrdinal("running_job"));
                agent.Sent_Job = rdr.GetInt32(rdr.GetOrdinal("sent_job"));
            }
            conn.Close();

            return agent;
        }

        /// <summary>
        /// Set agent to isrunning in database
        /// </summary>
        /// <param name="agent">Agent to set</param>
        public static void SetAgentRunning(string agent)
        {
            MySqlConnection conn = new MySqlConnection(DBConstants.connstring);
            conn.Open();
            string sql = String.Format("UPDATE agents set running_job = 1, sent_job = 1 where agent_name = '{0}'", agent);
            MySqlCommand comm = new MySqlCommand(sql, conn);
            comm.ExecuteNonQuery();
            conn.Close();
        }

        /// <summary>
        /// Set agent to isqueued in database
        /// </summary>
        /// <param name="agent">Agent to set</param>
        public static void SetAgentQueued(string agent)
        {
            MySqlConnection conn = new MySqlConnection(DBConstants.connstring);
            conn.Open();
            string sql = String.Format("UPDATE agents set running_job = 0, sent_job = 1 where agent_name = '{0}'", agent);
            MySqlCommand comm = new MySqlCommand(sql, conn);
            comm.ExecuteNonQuery();
            conn.Close();
        }

        /// <summary>
        /// Set agent to isidle in database
        /// </summary>
        /// <param name="agent">Agent to set</param>
        public static void SetAgentIdle(string agent)
        {
            MySqlConnection conn = new MySqlConnection(DBConstants.connstring);
            conn.Open();
            string sql = String.Format("UPDATE agents set running_job = 0, sent_job = 0, is_dead = 0 where agent_name = '{0}'", agent);
            MySqlCommand comm = new MySqlCommand(sql, conn);
            comm.ExecuteNonQuery();
            conn.Close();
        }

        /// <summary>
        /// Set agent to isdead in database
        /// </summary>
        /// <param name="agent">Agent to set</param>
        public static void SetAgentDead(string agent)
        {
            MySqlConnection conn = new MySqlConnection(DBConstants.connstring);
            conn.Open();
            string sql = String.Format("UPDATE agents set running_job = 0, sent_job = 0, is_dead = 1 where agent_name = '{0}'", agent);
            MySqlCommand comm = new MySqlCommand(sql, conn);
            comm.ExecuteNonQuery();
            conn.Close();
        }


        /// <summary>
        /// Add Agent with machine object
        /// </summary>
        /// <param name="agent">Agent object</param>
        public static void Add(Agent agent)
        {
            if(agent.Pool == null)
            {
                agent.Pool = "Default";
            }

            if(agent.OS == "Unknown")
            {
                agent.OS = "WIN10";
            }

            int mach_pool = PoolInteraction.Get(agent.Pool);
            int mach_os = OSInteraction.GetPK(agent.OS);
            MySqlConnection conn = new MySqlConnection(DBConstants.connstring);
            conn.Open();
            string sql = string.Format("INSERT IGNORE INTO agents (agent_name, fk_pool, fk_os, ip_address, is_dead) VALUES ('{0}', {1}, {2}, '{3}', 1)", agent.Name, mach_pool, mach_os, agent.IP);
            MySqlCommand comm = new MySqlCommand(sql, conn);
            comm.ExecuteNonQuery();
            conn.Close();
        }

        /// <summary>
        /// Delete agent from database based on name
        /// </summary>
        /// <param name="name">Agent Name</param>
        public static void Delete(string name)
        {
            MySqlConnection conn = new MySqlConnection(DBConstants.connstring);
            conn.Open();
            string sql = string.Format("DELETE FROM agents WHERE agent_name = '{0}'", name);
            MySqlCommand comm = new MySqlCommand(sql, conn);
            comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}