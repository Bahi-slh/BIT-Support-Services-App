using BITWebApp.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BITWebApp.Models
{
    //TODO  : not using this class
    public class Client
    {
        public int ClientId { get; set; }
        public string Title { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Dob { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string Address { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }


        public string StatusId { get; set; }


        private SQLHelper _db; 

        private void GeneratePassword()
        {
            this.Password = "welcome";
        }
        //public string AddClient()
        //{
        //    GeneratePassword();
        //    string insertsql= "insert into Client (title, firstname, lastname, dob, address, suburb, state, postcode,  phone, email, password, statusId)" + "values(@Title, @Firstname, @Lastname, @Dob,  @Address, @Suburb, @State, @Postcode, @Phone, @Email, @Password, @StatusId)";
        //    SqlParameter[] objParams = new SqlParameter[12];

        //    objParams[0] = new SqlParameter("@Title", DbType.String);
        //    objParams[0].Value = this.Title;

        //    objParams[1] = new SqlParameter("@Firstname", DbType.String);
        //    objParams[1].Value = this.Firstname;

        //    objParams[2] = new SqlParameter("@Lastname", DbType.String);
        //    objParams[2].Value = this.Lastname;

        //    objParams[3] = new SqlParameter("@Dob", DbType.String);
        //    objParams[3].Value = this.Dob;

        //    objParams[4] = new SqlParameter("@Address", DbType.String);
        //    objParams[4].Value = this.Address;

        //    objParams[5] = new SqlParameter("@Suburb", DbType.String);
        //    objParams[5].Value = this.Suburb;

        //    objParams[6] = new SqlParameter("@State", DbType.String);
        //    objParams[6].Value = this.State;

        //    objParams[7] = new SqlParameter("@Postcode", DbType.String);
        //    objParams[7].Value = this.Postcode;

        //    objParams[8] = new SqlParameter("@Phone", DbType.String);
        //    objParams[8].Value = this.Phone;

        //    objParams[9] = new SqlParameter("@Email", DbType.DateTime);
        //    objParams[9].Value = this.Email;

        //    objParams[10] = new SqlParameter("@Password", DbType.String);
        //    objParams[10].Value = this.Password;

        //    objParams[11] = new SqlParameter("@StatusId", DbType.Int32);
        //    objParams[11].Value = this.StatusId;

        //    _db = new SQLHelper();
        //    int rowsAffected = _db.ExecuteNonQuery(insertsql, objParams);
        //    if (rowsAffected >= 1)
        //    {
        //        return "New Client registered successfully!";
        //    }


        //    return "Registration was not successful, please try again.";
        //}

        


    }
}
