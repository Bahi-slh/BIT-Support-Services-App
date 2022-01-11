using BITWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BITWebApp.Views
{
    public partial class AllClientJobs : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ClientId"] != null)
            {
                TrueDynamicClientLinks();
                noItems.Visible = false;
                noHistory.Visible = false;

                int clientId = Convert.ToInt32(Session["ClientId"]);
                ClientJobRequests clientJobRequests = new ClientJobRequests();
                gvJobRequests.DataSource = clientJobRequests.JobRequests(clientId);
                gvJobRequests.DataBind();

                if (gvJobRequests.Rows.Count != 0) { 
                    //this.gvJobRequests.Columns[0].Visible = false;
                    gvJobRequests.HeaderRow.Cells[0].Visible = false;
                foreach (GridViewRow row in gvJobRequests.Rows)
                {
                    row.Cells[0].Visible = false;
                }}
                if (gvJobRequests.Rows.Count == 0)
                {
                    noHistory.Visible = true;
                }


                
                gvJobsNotAssignedYet.DataSource = clientJobRequests.JobRequestsNotAssignedYet(clientId);
                gvJobsNotAssignedYet.DataBind();
                if (gvJobsNotAssignedYet.Rows.Count == 0)
                {

                    noItems.Visible = true;
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }

           
        }
        public void TrueDynamicClientLinks()
        {
            LinkButton newJobRequestLink = (LinkButton)this.Master.FindControl("lbtnNewJobRequest");
            newJobRequestLink.Visible = true;

            LinkButton loginLink = (LinkButton)this.Master.FindControl("lbtnUserLogin");
            loginLink.Visible = false;

            LinkButton logoutLink = (LinkButton)this.Master.FindControl("lbtnUserLogout");
            logoutLink.Visible = true;

            LinkButton clientJobReqsLink = (LinkButton)this.Master.FindControl("lbtnClientJobReqs");
            clientJobReqsLink.Visible = true;

        }

    }
}