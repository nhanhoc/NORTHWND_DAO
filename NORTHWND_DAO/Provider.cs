using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace Northwnd
{
    class Provider
    {
 //       static string ConnectionString = @"Data Source=ABCDEFGHZT;Initial Catalog=NORTHWND;Integrated Security=True";
        private static string connectionString = "";

        public static string ConnectionString
        {
            get
            {
                if (connectionString.CompareTo("") == 0)
                {
                    connectionString = ConfigurationManager.ConnectionStrings["NorthWnd"].ConnectionString;
                }
                return connectionString;
            }
        }
        SqlConnection Connection { get; set; }
        public void Connect()
        {
            try
            {
                if (Connection == null)
                    Connection = new SqlConnection(ConnectionString);
                if (Connection.State != ConnectionState.Closed)
                    Connection.Close();
                Connection.Open();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public void Disconnect()
        {
            if (Connection != null && Connection.State == ConnectionState.Open)
                Connection.Close();
        }
        public int ExecuteNonQuery(CommandType cmdType,string str,params SqlParameter[] parameters)
        {
            try
            {
                SqlCommand command = Connection.CreateCommand();
                command.CommandText = str;
                command.CommandType = cmdType;
                if (parameters != null && parameters.Length > 0)
                {
                    command.Parameters.AddRange(parameters);
                }
                int nRow = command.ExecuteNonQuery();
                return nRow;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public int GetFirstValue(CommandType cmdType, string str, params SqlParameter[] parameters)
        {
            try
            {
                SqlCommand command = Connection.CreateCommand();
                command.CommandText = str;
                command.CommandType = cmdType;
                if (parameters != null && parameters.Length > 0)
                {
                    command.Parameters.AddRange(parameters);
                }
                int value = (int)command.ExecuteScalar();
                return value;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }  
        public DataTable Select(CommandType cmdType, string str,params SqlParameter[] parameters)
        {
            try
            {
                SqlCommand command = Connection.CreateCommand();
                command.CommandText = str;
                command.CommandType = cmdType;
                if (parameters != null && parameters.Length > 0)
                {
                    command.Parameters.AddRange(parameters);
                }
                SqlDataAdapter d = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                d.Fill(dt);
                return dt;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public SqlDataReader GetReader(CommandType cmd, string str)
        {
            try
            {
                SqlCommand command = Connection.CreateCommand();
                command.CommandText = str;
                command.CommandType = cmd;
                return command.ExecuteReader();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<string> CbList(CommandType cmd,string str,string a)
        {
            try
            {
                List<string> lst = new List<string>();
                SqlCommand command = Connection.CreateCommand();
                command.CommandText = str;
                command.CommandType = cmd;
                SqlDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    lst.Add(reader[a].ToString());
                }
                return lst;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
