using BITWebApp.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BITWebApp.Models
{
    public class ContractorJobRequest
    {
        public int JobRequestId { get; set; }
        public int AvailabilityId { get; set; }
        public int ClientId { get; set; }
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
        public string JobAddress { get; set; }
        public string JobSuburb { get; set; }
        public string JobState { get; set; }
        public string JobPostCode { get; set; }
        public DateTime AvailDate { get; set; }
        public string StartTime { get; set; }
        public string Description { get; set; }
        private SQLHelper _db;
        public ContractorJobRequest()
        {
            _db = new SQLHelper();
        }
        public ContractorJobRequest(DataRow dr)
        {
            JobRequestId = Convert.ToInt32(dr["jobReqId"].ToString());
            AvailabilityId = Convert.ToInt32(dr["availabilityId"].ToString());
            ClientId = Convert.ToInt32(dr["clientId"].ToString());
            ClientFirstName = dr["firstname"].ToString();
            ClientLastName = dr["lastname"].ToString();
            JobAddress = dr["address"].ToString();
            JobSuburb = dr["suburb"].ToString();
            JobState = dr["state"].ToString();
            JobPostCode = dr["postCode"].ToString();
            AvailDate = Convert.ToDateTime(dr["availDate"].ToString());
            StartTime = dr["startTime"].ToString();
            Description = dr["description"].ToString();
            _db = new SQLHelper();
        }
        public int AcceptedJob(int jobRequestId)
        {
            string sql = "UPDATE jobRequest set statusId = '1' where " +
                " jobReqId= " + jobRequestId;
            return _db.ExecuteNonQuery(sql);
        }
        public int RejectedJob(int jobRequestId)
        {
            string sql = "UPDATE jobRequest set statusId = '2' where " +
                " jobReqId= " + jobRequestId;
            return _db.ExecuteNonQuery(sql);
        }
        public int CompleteJob(int jobRequestId, int kmsDriven, string jobDuration, string feedback)
        {
            string sql = "UPDATE jobRequest set statusId = '3'  " +
                " WHERE " +
               " jobReqId= " + jobRequestId +
               "  insert into jobHistory(jobReqId, kmsDriven,jobDuration, feedback) " +
                "values('" +jobRequestId+
                "', '" +kmsDriven+
                "', '" + jobDuration+
                "', '" + feedback+
                "')";
            return _db.ExecuteNonQuery(sql);
        }
    }
}