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
    class CompletedJobs : List<CompletedJob>
    {
        public CompletedJobs()
        {
            SQLHelper helper = new SQLHelper();
            string sql = "select j.jobReqId, j.clientId, c.firstname, c.lastname, cr.firstname as crFName, cr.lastname as crLName, j.availabilityId, j.bookingDate, j.statusId, j.staffid, j.description, j.address, j.suburb, j.state, j.postcode, j.jobPriority, jh.jobReqId, jh.kmsDriven, jh.jobDuration, jh.feedback from jobRequest j,jobHistory jh, client c , Contractor cr, Availability a where j.statusId='3' and j.jobReqId=jh.jobReqId and c.clientId=j.clientId and cr.contractorId=a.contractorId and a.availabilityId=j.availabilityId";
            DataTable completedJobTable = helper.ExecuteSQL(sql);
            foreach (DataRow dr in completedJobTable.Rows)
            {
                CompletedJob cj = new CompletedJob(dr);
                this.Add(cj);
            }
        }
    }
}
