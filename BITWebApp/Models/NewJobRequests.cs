using BITWebApp.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BITWebApp.Models
{
    public class NewJobRequests
    {
        public DataTable AllNewJobRequests()
        {
            SQLHelper helper = new SQLHelper();
            string sql = "set dateformat dmy; SELECT j.jobreqid, c.clientId, c.firstName as [Client's Firstname], c.lastname as [Client's Lastname], j.description as [Description],  j.address as [Address], j.suburb [Suburb], j.state [State], j.postcode [Postcode],  j.bookingDate [Latest Possible Date of Job], j.jobpriority as [Job Priority] " +
                         " FROM jobRequest j, client c " +
                         " Where c.clientId = j.clientId and "+
                         " j.statusId = '5' ";

            return helper.ExecuteSQL(sql);
        }
    }
}