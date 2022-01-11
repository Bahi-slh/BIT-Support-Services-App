using BITWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BITWebApp.Views
{
    public partial class ContractorAcceptedJobs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["contractorId"] != null)
                {
                    LinkButton acceptedjobReqsLink = (LinkButton)this.Master.FindControl("lbtnAcceptedjobReqs");
                    acceptedjobReqsLink.Visible = false;

                    LinkButton assignedJobsLink = (LinkButton)this.Master.FindControl("lbtnAssignedJobs");
                    assignedJobsLink.Visible = true;

                    LinkButton loginLink = (LinkButton)this.Master.FindControl("lbtnUserLogin");
                    loginLink.Visible = false;

                    LinkButton logoutLink = (LinkButton)this.Master.FindControl("lbtnUserLogout");
                    logoutLink.Visible = true;

                    RefreshGrid();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        public void RefreshGrid()
        {
            noItems.Visible = false;
            int contractorId = Convert.ToInt32(Session["contractorId"]);
             AcceptedJobs allAcceptedJobs = new AcceptedJobs();

            gvAcceptedJobs.DataSource = allAcceptedJobs.AllAcceptedJobs(contractorId);
            gvAcceptedJobs.DataBind();
            if (gvAcceptedJobs.Rows.Count != 0)
            {
                
                gvAcceptedJobs.HeaderRow.Cells[4].Visible = false;
                gvAcceptedJobs.HeaderRow.Cells[5].Visible = false;
                gvAcceptedJobs.HeaderRow.Cells[6].Visible = false;
                foreach (GridViewRow row in gvAcceptedJobs.Rows)
                {
                    row.Cells[6].Visible = false;
                    row.Cells[5].Visible = false;
                    row.Cells[4].Visible = false;

                }
            }
                if (gvAcceptedJobs.Rows.Count == 0)
            {
                noItems.Visible = true;
            }

        }

        protected void gvAcceptedJobs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ContractorJobRequest jobReq = new ContractorJobRequest();
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvAcceptedJobs.Rows[rowIndex];
            if (e.CommandName == "Complete")
            {

                //Make sure these are the places you may need to have some validation 
                //If statements
                int kms = Convert.ToInt32(((TextBox)row.FindControl("txtKmsDriven")).Text.Trim());
                string hours = Convert.ToString(((TextBox)row.FindControl("txtJobDuration")).Text.Trim());
                string feedback = Convert.ToString(((TextBox)row.FindControl("txtFeedback")).Text);
                jobReq.CompleteJob(Convert.ToInt32(row.Cells[4].Text), kms, hours, feedback);
                RefreshGrid();
            }
        }
    }
}