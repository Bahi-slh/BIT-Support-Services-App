using BITWebApp.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BITWebApp.Models
{
    public class RejectedJobs
    {
        public DataTable AllRejectedJobs()
        {
            SQLHelper helper = new SQLHelper();
            string sql = "set dateformat dmy; SELECT j.jobreqid, a.availabilityId ,c.firstName as [Clinet's Firstname], c.lastname as [Clinet's Lastname],  c.clientId, j.description [Description], j.jobpriority as [Job Priority], " +
                         " j.address as [Address], j.suburb as [Suburb], j.state as [State], j.postcode as [Postcode], j.bookingDate as [Latest Date of Job] " +
                         " FROM jobRequest j, client c, contractor cr, " +
                         "  availability a " +
                         " WHERE a.availabilityId = j.availabilityId AND " +
                         " c.clientId = j.clientId AND " +
                         " cr.contractorid = a.contractorId AND " +
                         
                        
                         " j.statusId = '2' order by j.jobpriority";

            return helper.ExecuteSQL(sql);
        }

    }
}