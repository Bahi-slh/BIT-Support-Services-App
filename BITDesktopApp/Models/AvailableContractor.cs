using BITDesktopApp.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITDesktopApp.Models
{
    public class AvailableContractor : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int _timeSlotId;
        private string _startTime;
        private int _availabilityId;
        private DateTime _availDate;
        private int _contractorId;
        private string _contFirstName;
        private string _contLastName;
        private string _address;
        private string _suburb;
        private string _state;
        private string _postcode;
        private string _skills;
        private SQLHelper _db;
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        
        public int TimeSlotId
        {
            get { return _timeSlotId; }
            set { _timeSlotId = value; }
        }
        public string StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }
        public int AvailabilityId
        {
            get
            {
                return _availabilityId;
            }
            set { _availabilityId = value; }
        }
        public DateTime AvailDate
        {
            get { return _availDate; }
            set { _availDate = value; }
        }
        public int ContractorId
        {
            get { return _contractorId; }
            set { _contractorId = value; }
        }
        public string ContFirstName
        {
            get { return _contFirstName; }
            set { _contFirstName = value; }
        }
        public string ContLastName
        {
            get { return _contLastName; }
            set { _contLastName = value; }
        }
        public string ContAddress
        {
            get { return _address; }
            set { _address = value; }
        }

        public string ContSuburb
        {
            get { return _suburb; }
            set { _suburb = value; }
        }

        public string ContState
        {
            get { return _state; }
            set { _state = value; }
        }

        public string ContPostcode
        {
            get { return _postcode; }
            set { _postcode = value; }
        }

        public string Skills
        {
            get { return _skills; }
            set { _skills = value; }
        }

        public AvailableContractor()
        {
            _db = new SQLHelper();
            
        }
        public AvailableContractor(DataRow dr)
        {
            // select t.timeslotID, t.starttime, " +
            //"a.availabilityID, a.availDate, c.contractorID, c.firstname, c.lastname, s.[desc] " +
            this.ContFirstName = dr["firstname"].ToString();
            this.ContLastName = dr["lastname"].ToString();
            this.ContAddress = dr["Address"].ToString();
            this.ContSuburb = dr["Suburb"].ToString();
            this.ContState = dr["State"].ToString();
            this.ContPostcode = dr["Postcode"].ToString();
            this.Skills = dr["Skills"].ToString();
            this.StartTime = dr["starttime"].ToString();
            this.TimeSlotId = Convert.ToInt32(dr["timeslotID"].ToString());
            this.AvailabilityId = Convert.ToInt32(dr["availabilityId"].ToString());
            this.AvailDate = Convert.ToDateTime(dr["availDate"].ToString());
            this.ContractorId = Convert.ToInt32(dr["contractorID"].ToString());
            
            _db = new SQLHelper();

        }
    }
}
