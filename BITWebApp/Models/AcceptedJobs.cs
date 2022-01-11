using BITWebApp.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BITWebApp.Models
{
    public class AcceptedJobs
    {
        public DataTable AllAcceptedJobs(int contractorId)
        {
            SQLHelper helper = new SQLHelper();
            string sql = "SELECT j.jobreqid ,a.availabilityId, c.clientId, c.firstName as [Client's Firstname],  c.lastName as [Client's Lastname]," +
                         " j.Address, j.Suburb, j.State, j.Postcode, a.availDate as [Job Date], t.starttime as [Start Time]" +
                         " FROM availability a, timeslot t, jobrequest j, client c, contractor cr" +
                         " WHERE a.availabilityId = j.availabilityId AND" +
                         " c.clientId = j.clientId AND " +
                         " cr.contractorid = a.contractorId AND" +
                         " t.timeslotId = a.timeSlotId AND" +
                         " cr.contractorId = " + contractorId + " AND j.statusId = '1'";
            return helper.ExecuteSQL(sql);
        }
        public DataTable AllAcceptedJobs()
        {
            //when you list all the boookings you may need to show customer's full name and the instructor's full name with appropriate column names (Alias)
            SQLHelper helper = new SQLHelper();
            string sql = "SELECT j.jobreqid,a.availabilityId, c.clientId, c.firstName as [Client's Firstname],  c.lastName [Client's Lastname], cr.firstname as [Contractor's firstname], cr.lastname as [Contractor's Lastname], " +
                         " j.Address, j.Suburb, j.State, j.Postcode, a.availDate as [Booked Date], t.starttime as [Start Time], j.Description" +
                         " FROM availability a, timeslot t, jobrequest j, client c, contractor cr" +
                         " WHERE a.availabilityId = j.availabilityId AND" +
                         " c.clientId = j.clientId AND " +
                         " cr.contractorid = a.contractorId AND" +
                         " t.timeslotId = a.timeSlotId AND" +
                          " j.statusid = '1'";
            return helper.ExecuteSQL(sql);
        }
    }
}