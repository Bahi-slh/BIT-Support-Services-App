using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using BITDesktopApp.DAL;

namespace BITDesktopApp.Models
{
    public class CompletedJob : INotifyPropertyChanged
    {
        private int _jobReqId;
        private int _clientId;
        private DateTime _bookingDate;
        private int _availabilityId;
        private string  _statusId;
        private int _staffId;
        private string _description;
        private string _address;
        private string _suburb;
        private string _state;
        private string _postcode;
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
        public DateTime BookingDate { get { return _bookingDate; } set { _bookingDate = value; } }
        public int AvailabilityId { get { return _availabilityId; } set { _availabilityId = value; } }
        public string  StatusId 
        { get 
            { return _statusId; } 
            set 
            {
                if (value == "2")
                {
                    _statusId = "Rejected";
                }
                else if (value == "3")
                {
                    _statusId = "Completed";
                }
                else if (value == "4")
                {
                    _statusId = "Verified";
                }
                else if (value == "Rejected")
                {
                    _statusId = "2";
                }
                else if (value == "Completed")
                {
                    _statusId = "3";
                }
                else if (value == "Verified")
                {
                    _statusId = "4";
                }
                OnPropertyChanged("StatusId");
            } 
        }
        public int StaffId { get { return _staffId; } set { _staffId = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public string Address { get { return _address; } set { _address = value; } }
        public string Suburb { get { return _suburb; } set { _suburb = value; } }
        public string State { get { return _state; } set { _state = value; } }
        public string Postcode { get { return _postcode; } set { _postcode = value; } }
        public string ClientFName { get; set; }
        public string ClientLName { get; set; }
        public string ContractorFName { get; set; }
        public string ContractorLName { get; set; }
        public string JobPriority { get; set; }
        public decimal KmsDriven { get; set; }
        public decimal JobDuration { get; set; }
        public string Feedback { get; set; }
        
        public CompletedJob()
        {
            _db = new SQLHelper();
        }

        public CompletedJob(DataRow dr)
        {
            this.ClientId = Convert.ToInt32(dr["clientId"].ToString());
            this.ClientFName = dr["firstname"].ToString();
            this.ClientLName = dr["lastname"].ToString();
            this.ContractorFName = dr["crFName"].ToString();
            this.ContractorLName = dr["crLName"].ToString();
            this.Suburb = dr["suburb"].ToString();
            this.JobReqId = Convert.ToInt32(dr["jobReqId"].ToString());
            this.BookingDate = Convert.ToDateTime(dr["bookingDate"].ToString());
            this.AvailabilityId = Convert.ToInt32(dr["availabilityId"].ToString());
            this.StatusId = dr["statusId"].ToString();
            this.StaffId = Convert.ToInt32(dr["staffId"].ToString());
            this.Description = dr["description"].ToString();
            this.Address = dr["address"].ToString();
            this.Suburb = dr["suburb"].ToString();
            this.Postcode = dr["postcode"].ToString();
            this.State = dr["state"].ToString();
            this.JobPriority = dr["jobPriority"].ToString();
            KmsDriven = Convert.ToDecimal(dr["kmsDriven"].ToString());
            JobDuration = Convert.ToDecimal(dr["jobDuration"].ToString());
            Feedback = dr["feedback"].ToString();
            _db = new SQLHelper();


        }
        public string UpdateStatus()
        {
            //int returnValue = 1;
                if (this.StatusId == "3")
                {
                return "Job Status remained the same!";
                }
                 string sql = "set dateformat dmy; update jobRequest set " +
                " statusId = '" + this.StatusId + "' where jobReqId='"+this.JobReqId+"'";
            int rowsAffected = _db.ExecuteNonQuery(sql);
            if (rowsAffected >= 1)
            {
                return "The job status updated successfully!";
            }
            return "The job status didn't update successfully, please try again.";
        }
    }

}
