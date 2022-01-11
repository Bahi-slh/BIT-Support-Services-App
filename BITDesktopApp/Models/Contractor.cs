using BITDesktopApp.BLL;
using BITDesktopApp.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITDesktopApp.Models
{
    public class Contractor : INotifyPropertyChanged, IDataErrorInfo
    {
        private ObtainedSkill _os;
        //private ObtainedSkills _obtainedSkillss;
        private NotObtainedSkill _nos;
        //private NotObtainedSkills _nObtainedSkills;
        private string _statusId;
        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();

        private ObservableCollection<NotObtainedSkill> _notObtainedSkills;
        private ObservableCollection<ObtainedSkill> _obtainedSkills;
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        public string Error { get { return null; } }

        public string this[string propertyName]
        {
            get
            {
                string result = null;
                switch (propertyName)
                {
                    case "Title":
                        if (string.IsNullOrWhiteSpace(Title)) { result = "Title cannot be empty"; }

                        break;
                    case "Firstname":
                        if (string.IsNullOrWhiteSpace(Firstname))
                            result = "Firstname cannot be empty";
                        break;

                    case "Lastname":
                        if (string.IsNullOrWhiteSpace(Lastname))
                            result = "Lastname cannot be empty";
                        break;
                    //case "Dob":
                    //    if (DateOfBirthDate(Dob))
                    //        result = "Ages over 100 are invalid";
                    //    break;
                    case "Phone":
                        if (string.IsNullOrWhiteSpace(Phone))
                        {
                            result = "Phone cannot be empty";
                        }
                        else
                        {
                            try
                            {
                                Convert.ToInt64(Phone);
                                result = null;
                            }
                            catch
                            {
                                result = "Invalid Phone number";
                            }

                        }
                        break;
                    case "Email":
                        if (string.IsNullOrWhiteSpace(Email))
                            result = "Email cannot be empty";
                        break;
                    case "Address":
                        if (string.IsNullOrWhiteSpace(Address))
                            result = "Address cannot be empty";
                        break;
                    case "Suburb":
                        if (string.IsNullOrWhiteSpace(Suburb))
                            result = "Suburb cannot be empty";
                        break;
                    case "State":
                        if (string.IsNullOrWhiteSpace(State))
                            result = "State cannot be empty";
                        break;
                    case "Postcode":
                        if (string.IsNullOrWhiteSpace(Postcode))
                            result = "Postcode cannot be empty";
                        break;
                    case "Rating":
                        if (Rating==0)
                            result = "Rating cannot be empty";
                        break;

                }
                OnPropertyChanged("ErrorCollection");
                if (result != null && !ErrorCollection.ContainsKey(propertyName)) { ErrorCollection.Add(propertyName, result); }

                OnPropertyChanged("ErrorCollection");
                return result;

            }
        }

        public int ContractorId { get; set; }
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
        public decimal Rating { get; set; }
        public string StatusId 
        {
            get { return _statusId; } 
            set 
            { if (value == "0") 
                {
                    _statusId = "Inactive"; 
                }
               else if(value == "1") 
                {
                    _statusId = "Active"; 
                }
                else if (value == "Active")
                {
                    _statusId= "1";
                }
                else if (value == "Inactive")
                {
                    _statusId = "0";
                }
            } 
        }
        private SQLHelper _db;



        public Contractor() //default constructor
        {
            //_db = new SQLHelper();
        }
        public ObservableCollection<ObtainedSkill> ObtainedSkills
        {
            get { return _obtainedSkills; }
            set
            {

                _obtainedSkills = value;
                OnPropertyChanged("ObtainedSkills");
            }
        }



        public ObtainedSkill OS
        {
            get { return _os; }
            set { _os = value;
                OnPropertyChanged("OS");
            }
        }

        public ObservableCollection<NotObtainedSkill> NotObtainedSkills
        {
            get { return _notObtainedSkills; }
            set
            {

               _notObtainedSkills = value;
                OnPropertyChanged("NotObtainedSkills");
            }
        }

        public NotObtainedSkill NotObtainedSkill
        {
            get { return _nos; }
            set { _nos = value;
                OnPropertyChanged("NotObtainedSkill");
            }
        }

       

        private void GeneratePassword()
        {
            this.Password = "welcome";
        }

        public Contractor(DataRow dr)
        {
            this.ContractorId = Convert.ToInt32(dr["contractorId"].ToString());

            ObtainedSkills allObtainedSkills = new ObtainedSkills(ContractorId);
            this.ObtainedSkills = new ObservableCollection<ObtainedSkill>(allObtainedSkills);

            this.OS = new ObtainedSkill();

            NotObtainedSkills allNotObtainedSkills = new NotObtainedSkills(ContractorId);
            this.NotObtainedSkills = new ObservableCollection<NotObtainedSkill>(allNotObtainedSkills);


            this.NotObtainedSkill = new NotObtainedSkill();
            
            this.Title = dr["title"].ToString();
            this.Firstname = dr["firstname"].ToString();
            this.Lastname = dr["lastname"].ToString();
            this.Email = dr["email"].ToString();
            this.Phone = dr["phone"].ToString();
            this.Address = dr["address"].ToString();
            this.Suburb = dr["suburb"].ToString();
            this.Postcode = dr["postcode"].ToString();
            this.State = dr["state"].ToString();
            this.Dob = Convert.ToDateTime(dr["dob"].ToString());
            this.StatusId = dr["statusId"].ToString();
            this.Rating = Convert.ToDecimal(dr["rating"].ToString());
            _db = new SQLHelper();

        }

        public string AddContractor()
        {
            if (Firstname != "" && Lastname != "" && Address != "" && Suburb != "" && State != "" && Postcode != "" && Email != "" && Phone != "" && Title != "" && IsPhoneValid(Phone))
            {
                GeneratePassword();
                string insertsql = "set dateformat dmy; insert into Contractor (title, firstname, lastname, dob, address, suburb, state, postcode,  phone, email, password, statusId, rating)" + "values(@Title, @Firstname, @Lastname, @Dob,  @Address, @Suburb, @State, @Postcode, @Phone, @Email, @Password, @StatusId, @rating)";
                SqlParameter[] objParams = new SqlParameter[13];

                objParams[0] = new SqlParameter("@Title", DbType.String);
                objParams[0].Value = this.Title;

                objParams[1] = new SqlParameter("@Firstname", DbType.String);
                objParams[1].Value = this.Firstname;

                objParams[2] = new SqlParameter("@Lastname", DbType.String);
                objParams[2].Value = this.Lastname;

                objParams[3] = new SqlParameter("@Dob", DbType.String);
                objParams[3].Value = this.Dob;

                objParams[4] = new SqlParameter("@Address", DbType.String);
                objParams[4].Value = this.Address;

                objParams[5] = new SqlParameter("@Suburb", DbType.String);
                objParams[5].Value = this.Suburb;

                objParams[6] = new SqlParameter("@State", DbType.String);
                objParams[6].Value = this.State;

                objParams[7] = new SqlParameter("@Postcode", DbType.String);
                objParams[7].Value = this.Postcode;

                objParams[8] = new SqlParameter("@Phone", DbType.String);
                objParams[8].Value = this.Phone;

                objParams[9] = new SqlParameter("@Email", DbType.DateTime);
                objParams[9].Value = this.Email;

                objParams[10] = new SqlParameter("@Password", DbType.String);
                objParams[10].Value = this.Password;

                objParams[11] = new SqlParameter("@StatusId", DbType.Int32);
                objParams[11].Value = Convert.ToInt32("1");

                objParams[12] = new SqlParameter("@rating", DbType.Int32);
                objParams[12].Value = this.Rating;

                _db = new SQLHelper();
                int rowsAffected = _db.ExecuteNonQuery(insertsql, objParams);
                if (rowsAffected >= 1)
                {
                    return "New Contractor registered successfully!";
                }


                return "Registration was not successful, please try again."; 
            }
            else if (IsPhoneValid(Phone) == false)
            {
                return "Phone number is invalid!";
            }
            else
            {
                return "Please fill all textboxes!";
            }
        }
        public string ValidateStatus(string statusId)
        {

            if (statusId == "Active")
            {
                return "1";
            }
            else if (statusId == "Inactive")
            {
                return "0";
            }
            else
            {
                return statusId;
            }
        }
        public bool IsPhoneValid(string phone)
        {
            try
            {
                Convert.ToInt64(phone);
                return true;
            }
            catch
            {
                return false;
            }

        }
        public string UpdateContractor()
        {
            if (Firstname != "" && Lastname != "" && Address != "" && Suburb != "" && State != "" && Postcode != "" && Email != "" && Phone != "" && Title != "" && IsPhoneValid(Phone))
            {
                string sql = "set dateformat dmy; update contractor set" +
                " firstName = '" + this.Firstname + "'," +
                " lastName = '" + this.Lastname + "' ," +

                " address = '" + this.Address + "', " +
                " suburb = '" + this.Suburb + "', " +
                " state = '" + this.State + "', " +
                " postcode = '" + this.Postcode + "', " +
                " email = '" + this.Email + "', " +
                " phone = '" + this.Phone + "', " +
                " dob = '" + this.Dob + "', " +
                " statusId = '" + ValidateStatus(this.StatusId) + "', " +
                " rating = '" + this.Rating + "', " +
                " title= '" + this.Title + "' where contractorId = " + this.ContractorId;
                int rowsAffected = _db.ExecuteNonQuery(sql);
                if (rowsAffected >= 1)
                {
                    return "Contractor Detail was updated successfully!";
                }
                else { return "Contractor Detail was not updated successfully, please try again."; }
            }
            else
            {
                return "Please fill all textboxes!";
            }
        }

        public string DeleteContractorSkill()
        {
            string sql = "DELETE FROM ObtainedSkills WHERE contractorId='" +ContractorId+"' and "+
                "skillid = '" + OS.SkillId + "'";
            _db = new SQLHelper();
            int rowsAffected=_db.ExecuteNonQuery(sql);
            if (rowsAffected >= 1)
            {
                return "The Skill was deleted successfully!";
            }

            return "New skill was not deleted successfully, please try again.";
        }

        public string AddContractorSkill()
        {

            string insertsql = " insert into obtainedSkills ( Skillid, contractorId) " + "values(@SkillId ,@ContractorId)";
            SqlParameter[] objParams = new SqlParameter[2];

            objParams[0] = new SqlParameter("@SkillId", DbType.Int32);
            objParams[0].Value = this.NotObtainedSkill.SkillId;

            
            objParams[1] = new SqlParameter("@ContractorId", DbType.Int32);
            objParams[1].Value = this.ContractorId;



            _db = new SQLHelper();
            int rowsAffected = _db.ExecuteNonQuery(insertsql, objParams);
            if (rowsAffected >= 1)
            {
                return "The Skill was added successfully!";
            }

            return "New skill addition was not successful, please try again.";
        }


    }
}
