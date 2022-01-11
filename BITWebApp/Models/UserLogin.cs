using BITWebApp.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BITWebApp.Models
{
    public class UserLogin
    {
        public int UserId { get; set; }
        public string UserName { get; set; } //emails
        public string Password { get; set; }

        private SQLHelper _db;
        public UserLogin()
        {
            _db = new SQLHelper();
        }
        public bool IsClient()
        {
            string sql = "select * from client where email=@Username and password =@Password";
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@Username", DbType.String);
            objParams[0].Value = this.UserName;
            objParams[1] = new SqlParameter("@Password", DbType.String);
            objParams[1].Value = this.Password;

            DataTable usersTable = _db.ExecuteSQL(sql, objParams);
            if (usersTable.Rows.Count >= 1)
            {
                this.UserId = Convert.ToInt32(usersTable.Rows[0][0].ToString());
                return true;
            }
            return false;
        }
        public bool IsContractor()
        {
            string sql = "select * from contractor where email=@Username and password =@Password";
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@Username", DbType.String);
            objParams[0].Value = this.UserName;
            objParams[1] = new SqlParameter("@Password", DbType.String);
            objParams[1].Value = this.Password;

            DataTable usersTable = _db.ExecuteSQL(sql, objParams);
            if (usersTable.Rows.Count >= 1)
            {
                this.UserId = Convert.ToInt32(usersTable.Rows[0][0].ToString());
                return true;
            }
            return false;
        }
        public bool IsStaff()
        {
            string sql = "select * from staff where email=@Username and password =@Password";
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@Username", DbType.String);
            objParams[0].Value = this.UserName;
            objParams[1] = new SqlParameter("@Password", DbType.String);
            objParams[1].Value = this.Password;

            DataTable usersTable = _db.ExecuteSQL(sql, objParams);
            if (usersTable.Rows.Count >= 1)
            {
                this.UserId = Convert.ToInt32(usersTable.Rows[0][0].ToString());
                return true;
            }
            return false;
        }
    }
}