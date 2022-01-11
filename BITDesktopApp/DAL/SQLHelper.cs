using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//added by me
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BITDesktopApp.DAL
{
    public class SQLHelper
    {
        private string _conn;
        public SQLHelper()
        {
            _conn = ConfigurationManager.ConnectionStrings["BIT"].ConnectionString;
        }

        public DataTable ExecuteSQL(string sql, SqlParameter[] parameters = null, bool
       storedProcedure = false)
        {
            DataTable dataTable = new DataTable();
            SqlConnection dbConnection = new SqlConnection(_conn);
            SqlCommand dbCommand = new SqlCommand(sql, dbConnection);
            //Fire the query written in queryString using the connection object
            dbConnection.Open();
            if (storedProcedure == true)
            {
                dbCommand.CommandType = CommandType.StoredProcedure;
            }
            if (parameters != null)
            {
                AddParameters(dbCommand, parameters);
            }
            SqlDataReader drResults =
            dbCommand.ExecuteReader(CommandBehavior.CloseConnection);
            dataTable.Load(drResults);
            dbConnection.Close();
            return dataTable;
        }
        public void AddParameters(SqlCommand objCommand, SqlParameter[] parameters)
        {
            for (int i = 0; i < parameters.Length; i++)
            {
                objCommand.Parameters.Add(parameters[i]);
            }
        }
        public int ExecuteNonQuery(string sql, SqlParameter[] parameters = null, bool
        storedProcedure = false)
        {
            int returnValue = -1;
            SqlConnection dbConnection = new SqlConnection(_conn);
            SqlCommand dbCommand = new SqlCommand(sql, dbConnection);
            //Fire the query written in queryString using the connection object
            if (storedProcedure == true)
            {
                dbCommand.CommandType = CommandType.StoredProcedure;
            }
            if (parameters != null)
            {
                AddParameters(dbCommand, parameters);
            }
            dbConnection.Open();
            returnValue = dbCommand.ExecuteNonQuery();
            dbConnection.Close();
            return returnValue;
        }
    }
}
