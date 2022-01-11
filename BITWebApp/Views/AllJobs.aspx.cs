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
    public partial class AllJobs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["staffId"] != null)
            {
                LinkButton allNewJobReqsLink = (LinkButton)this.Master.FindControl("lbtnNewJobRequests");
                allNewJobReqsLink.Visible = true; 

                LinkButton allRejectedBookingLink = (LinkButton)this.Master.FindControl("lbtnAllRejectedJobs");
                allRejectedBookingLink.Visible = true;

                LinkButton allCompletedBookingLink = (LinkButton)this.Master.FindControl("lbtnAllCompletedJobs");
                allCompletedBookingLink.Visible = true;

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
        public void RefreshGrid()
        {
            noItems.Visible = false;
            AcceptedJobs alljobs = new AcceptedJobs();
            DataTable bookingsDT = alljobs.AllAcceptedJobs();
            gvBookedJobs.DataSource = bookingsDT;
            gvBookedJobs.DataBind();
            if (gvBookedJobs.Rows.Count != 0)
            {
                gvBookedJobs.HeaderRow.Cells[0].Visible = false;
                gvBookedJobs.HeaderRow.Cells[1].Visible = false;
                gvBookedJobs.HeaderRow.Cells[2].Visible = false;
                
                foreach (GridViewRow row in gvBookedJobs.Rows)
                {
                    row.Cells[0].Visible = false;
                    row.Cells[1].Visible = false;
                    row.Cells[2].Visible = false;

                }
            }
            if (gvBookedJobs.Rows.Count == 0)
            {
                noItems.Visible = true;

            }
        }
    }
}
