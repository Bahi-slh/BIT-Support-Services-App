using BITWebApp.DAL;
using BITWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BITWebApp.Views
{
    public partial class AllCompletedJobs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 
                if (Session["staffId"] != null)
                {
                    LinkButton allNewJobReqsLink = (LinkButton)this.Master.FindControl("lbtnNewJobRequests");
                    allNewJobReqsLink.Visible = true;
                    
                    LinkButton allJobsLink = (LinkButton)this.Master.FindControl("lbtnAllJobs");
                    allJobsLink.Visible = true;

                    LinkButton allRejectedBookingLink = (LinkButton)this.Master.FindControl("lbtnAllRejectedJobs");
                    allRejectedBookingLink.Visible = true;


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

            CompletedJobs allJobs = new CompletedJobs();
            gvCompletedJobs.DataSource = allJobs.AllCompletedJobs().DefaultView;
            gvCompletedJobs.DataBind();
            gvCompletedJobs.HeaderRow.Cells[0].Text = "";
            gvCompletedJobs.HeaderRow.Cells[1].Visible = false;
            foreach (GridViewRow row in gvCompletedJobs.Rows)
            {
                row.Cells[1].Visible = false;
                
            }
        }

        protected void gvCompletedJobs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Verify")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvCompletedJobs.Rows[rowIndex];
                int jobReqId = Convert.ToInt32(row.Cells[1].Text);
                string sql = " update jobRequest set statusId='4' where jobReqId='" + jobReqId + "'";
                SQLHelper helper = new SQLHelper();
                helper.ExecuteNonQuery(sql);
                RefreshGrid();
            }


        }
    }
}