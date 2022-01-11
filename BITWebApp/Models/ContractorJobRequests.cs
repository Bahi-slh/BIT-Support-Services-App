using BITWebApp.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BITWebApp.Models
{
    public class ContractorJobRequests :List<ContractorJobRequest>
    {
        public ContractorJobRequests(int contractorId)
        {
            SQLHelper helper = new SQLHelper();
            string sql = "SELECT j.jobReqId, a.availabilityId, c.clientId, c.firstname, c.lastname, j.address, j.suburb, j.state, j.postcode, a.availDate, t.startTime, j.[description] FROM availability a, client c, timeslot t, jobrequest j, contractor cr  " +
                 " WHERE a.availabilityId = j.availabilityId AND" +
                 " c.clientId = j.clientId AND " +
                 " cr.contractorid = a.contractorId AND" +
                 " t.timeslotId = a.timeSlotId AND" +
                 " cr.contractorId = " + contractorId + " AND j.statusId = '0'";
            DataTable bookings = helper.ExecuteSQL(sql);
            foreach (DataRow dr in bookings.Rows)
            {
                ContractorJobRequest aJobRequest = new ContractorJobRequest(dr);
                this.Add(aJobRequest);
            }
        }
    }
}