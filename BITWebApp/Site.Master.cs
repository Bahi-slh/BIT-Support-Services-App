using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BITWebApp
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtnUserLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void lbtnNewJobRequest_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewJobRequest.aspx");
        }


        protected void lbtnUserLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("homepage.aspx");
        }

        protected void lbtnClientJobReqs_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllClientJobs.aspx");
        }

        protected void lbtnAcceptedjobReqs_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContractorAcceptedJobs.aspx");
        }
        



        protected void lbtnAllRejectedJobs_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllRejectedJobs.aspx");
        }

        protected void lbtnAllJobs_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllJobs.aspx");
        }

        protected void lbtnAllCompletedJobs_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllCompletedJobs.aspx");
        }

   

        protected void lbtnNewJobRequests_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllNewJobRequests.aspx");
        }

        protected void lbtnAssignedJobs_Click(object sender, EventArgs e)
        {
            Response.Redirect("AllContractorJobs.aspx");
        }
    }
}