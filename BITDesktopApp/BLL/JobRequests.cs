using BITDesktopApp.DAL;
using BITDesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITDesktopApp.BLL
{
    class JobRequests : List<JobRequest>
    {
        public JobRequests()
        {
            SQLHelper helper = new SQLHelper();
            string sql = "select j.jobREqId, j.clientId, c.firstname, c.lastname, j.bookingDate, j.description, j.address, j.suburb, j.state, j.postcode, j.jobpriority from  jobRequest j, client c where j.statusId='5' and c.clientId=j.clientid";
            DataTable jobRequestTable = helper.ExecuteSQL(sql);
            foreach (DataRow dr in jobRequestTable.Rows)
            {
                JobRequest jb = new JobRequest(dr);
                this.Add(jb);
            }
        }
    }
}
