using BITWebApp.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BITWebApp.Models
{
    public class ClientJobRequests
    {
        public ClientJobRequests()
        {

        }
        public DataTable JobRequests(int clientId)
        {
            SQLHelper helper = new SQLHelper();
            string sql = "SELECT j.bookingDate, j.description as [Job Request Description], a.availDate as [Date of Job], t.startTime as [Job Start Time], c.firstname as [Contractor's Firstname] , c.lastname  as [Contractor's Lastname], js.status as [Job Request Status] " +
                "FROM jobRequest j, contractor c, Availability a, JobReqStatus js, TimeSlot t " +
                "WHERE j.availabilityId= a.availabilityId  AND " +
                "c.contractorId=a.contractorId AND " +
                "t.timeSlotId=a.timeslotid AND " +
                " js.statusId = j.statusId and " +
                "j.clientId= " + clientId;
            return (helper.ExecuteSQL(sql));
        }

        public DataTable JobRequestsNotAssignedYet(int clientId)
        {
            SQLHelper helper = new SQLHelper();
            string sql = "SELECT j.bookingDate as [Latest Possible Date of Job],j.description as [Job Request Description] , js.status as [Job Request Status]" +
                "FROM jobRequest j,  JobReqStatus js " +
                "WHERE j.statusId='5'  AND " +
                " js.statusId = j.statusId and " +
                "j.clientId= " + clientId;
            return (helper.ExecuteSQL(sql));
        }
    }
}