using BITWebApp.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BITWebApp.Models
{
    public class CompletedJobs
    {
        public DataTable AllCompletedJobs()
        {
            SQLHelper helper = new SQLHelper();
            string sql = "select j.jobReqId, c.firstname as [Client's Firstname], c.lastname as [Client's Lastname], cr.Firstname as [Contractor's Firstname], cr.lastname as [Contractor's Lastname], " +
              " jh.kmsDriven as [Driven Distance (km)], jh.jobDuration as [Job Duration (hour)], jh.feedback as [Feedback]" +
              " from jobRequest j, Availability a, Contractor cr, Client c, jobHistory jh " +
            "where j.statusId = '3' and " +
            "j.availabilityId = a.availabilityId and " +
            "a.contractorId = cr.contractorId and " +
            "j.clientId = c.clientId and " +
            "j.jobReqId = jh.jobReqId ";

            return helper.ExecuteSQL(sql);
        }

    }
}