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
using System.Windows;

namespace BITDesktopApp.Models
{
    public class JobRequest : INotifyPropertyChanged
    {
        private int _jobReqId;
        private int _clientId;
        private DateTime _bookingDate;
        //private int _availabilityId;
        private int _statusId;
        private int _staffId;
        private string _description;
        private string _address;
        private string _suburb;
        private string _state;
        private string _postcode;
        private string _searchText;
        private string _searchChoice;
        private AvailableContractor _availableContractor;
        private AvailableContractors _availableContractors;
        public event PropertyChangedEventHandler PropertyChanged;
        private SQLHelper _db;

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null) //this is checking if we do have an event handler
            {
                //PropertyChanged() is a delegate that will call an EventHandler
                //depending on who is Subscribed to listen to this event
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        
        public int JobReqId { get { return _jobReqId; } set { _jobReqId = value; } }
        public int ClientId { get { return _clientId; } set { _clientId = value; } }
        public string ClientFName { get; set; }
        public string ClientLName { get; set; }
        public DateTime BookingDate { get { return _bookingDate; } set { _bookingDate = value; } }
        public string AvailabilityId { get; set; }
        public int StatusId { get { return _statusId; } set { _statusId = value; } }
        public int StaffId { get { return _staffId; } set { _staffId = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public string Address { get { return _address; } set { _address = value; } }
        public string Suburb { get { return _suburb; } set { _suburb = value; } }
        public string State { get { return _state; } set { _state = value; } }
        public string Postcode { get { return _postcode; } set { _postcode = value; } }
        public string JobPriority { get; set; }

        public AvailableContractors AvailableContractors
        {
            get { return _availableContractors; }
            set
            {
                _availableContractors = value;
                OnPropertyChanged("AvailableContractors");
            }
        }

        public AvailableContractor AvailContractor
        {
            get { return _availableContractor; }
            set
            {
                _availableContractor = value;
                OnPropertyChanged("AvailContractor");
            }
        }
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value; OnPropertyChanged("SearchText");
            }
        }

        public string SearchChoice
        {
            get { return _searchChoice; }
            set
            {
                _searchChoice = value; OnPropertyChanged("SearchChoice");
            }
        }

        public JobRequest() //default constructor
        {
            _db = new SQLHelper();
        }
        public JobRequest(DataRow dr)
        {
            //AvailableContractors allAvailableConts = new AvailableContractors()
           
            
            this.ClientId = Convert.ToInt32(dr["clientId"].ToString());
            this.ClientFName = dr["firstname"].ToString();
            this.ClientLName= dr["lastname"].ToString();
            this.JobReqId = Convert.ToInt32(dr["jobReqId"].ToString());
            this.BookingDate = Convert.ToDateTime(dr["bookingDate"].ToString());
            //this.AvailabilityId = dr["availabilityId"].ToString();
            //this.StatusId = Convert.ToInt32(dr["statusId"].ToString());
            //this.StaffId = Convert.ToInt32(dr["staffId"].ToString());
            this.Description = dr["description"].ToString();
           
            this.Address = dr["address"].ToString();
            this.Suburb = dr["suburb"].ToString();
            this.Postcode = dr["postcode"].ToString();
            this.State = dr["state"].ToString();
            this.JobPriority = dr["jobPriority"].ToString();
            this.AvailableContractors = new AvailableContractors(BookingDate);
            this.AvailContractor = new AvailableContractor();
            _db = new SQLHelper();

        }

        //Add staffId after you have implememnted login
        public string AddJobRequest()
        {
            
            string insertsql = "set dateformat dmy; insert into jobRequest (clientId, bookingDate, statusId, description, address, suburb, state, postcode, jobpriority)" + "values(@ClientId, @BookingDate, @StatusId, @Description,  @Address, @Suburb, @State, @Postcode, @JobPriority)";

            
            SqlParameter[] objParams = new SqlParameter[9];

            objParams[0] = new SqlParameter("@ClientId", DbType.Int32);
            objParams[0].Value = this.ClientId;

            objParams[1] = new SqlParameter("@BookingDate", DbType.DateTime);
            objParams[1].Value = this.BookingDate;

            objParams[2] = new SqlParameter("@StatusId", DbType.Int32);
            objParams[2].Value = Convert.ToInt32("5");

            objParams[3] = new SqlParameter("@Description", DbType.String);
            objParams[3].Value = this.Description;

            objParams[4] = new SqlParameter("@Address", DbType.String);
            objParams[4].Value = this.Address;

            objParams[5] = new SqlParameter("@Suburb", DbType.String);
            objParams[5].Value = this.Suburb;

            objParams[6] = new SqlParameter("@State", DbType.String);
            objParams[6].Value = this.State;

            objParams[7] = new SqlParameter("@Postcode", DbType.String);
            objParams[7].Value = this.Postcode;

            objParams[8] = new SqlParameter("@JobPriority", DbType.String);
            objParams[8].Value = this.JobPriority;




            _db = new SQLHelper();
            int rowsAffected = _db.ExecuteNonQuery(insertsql, objParams);
            if (rowsAffected >= 1)
            {
                return "New Job Request was added successfully!";
            }


            return "New Job Request was not added successfully, please try again.";
        }

        public string AssignContractor()
        {
            string insertsql = "set dateformat dmy; update JobRequest SET availabilityId ='"+AvailContractor.AvailabilityId+"', statusId='0', staffId='1' WHERE jobReqId='"+this.JobReqId+ "' update Availability set status='NA' where availabilityId='" + AvailContractor.AvailabilityId + "'";
            int rowsAffected = _db.ExecuteNonQuery(insertsql);
            if (rowsAffected >= 1)
            {
                return "New Job Request was assigned successfully!";
            }


            return "New Job Request was not assinged successfully, please try again.";

        }

        public void SearchMethod()
        {

            try
            {
                if (this.SearchChoice == "Skill")
                {
                    AvailableContractors allContractors = new AvailableContractors(BookingDate, this.SearchText);
                    this.AvailableContractors = allContractors;
                }
                else { 
                AvailableContractors allContractors = new AvailableContractors(BookingDate,this.SearchChoice, this.SearchText);
                this.AvailableContractors = allContractors;
                }

            }
            catch
            {
                MessageBox.Show("Please enter your choice of search and fill the search box!");
            }
        }

    }
}
