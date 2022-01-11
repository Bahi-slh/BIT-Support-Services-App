using BITWebApp.DAL;
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
    public partial class AllNewJobRequests : System.Web.UI.Page // for staff
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["staffId"] != null)
                {
                    LinkButton allRejectedBookingLink = (LinkButton)this.Master.FindControl("lbtnAllRejectedJobs");
                    allRejectedBookingLink.Visible = true;

                    LinkButton acceptedjobReqsLink = (LinkButton)this.Master.FindControl("lbtnAllJobs");
                    acceptedjobReqsLink.Visible = true;

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
        }

        public void RefreshGrid()
        {
            hAvailableContracs.Visible = false;
            nojobReq.Visible = false;
            noAvailCont.Visible = false;
            NewJobRequests allJobs = new NewJobRequests();
            gvNewJobRequests.DataSource = allJobs.AllNewJobRequests().DefaultView;
            gvNewJobRequests.DataBind();
            if(gvNewJobRequests.Rows.Count != 0) { 
            gvNewJobRequests.HeaderRow.Cells[0].Text = "";
            gvNewJobRequests.HeaderRow.Cells[1].Visible = false;
            gvNewJobRequests.HeaderRow.Cells[2].Visible = false;
            foreach (GridViewRow row in gvNewJobRequests.Rows)
            {
                row.Cells[1].Visible = false;
                row.Cells[2].Visible = false;
            }}
            if(gvNewJobRequests.Rows.Count == 0)
            {
                nojobReq.Visible = true;
            }
        }

        protected void gvNewJobRequests_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvNewJobRequests.Rows[rowIndex];
            if (e.CommandName == "Find")
            {
                hAvailableContracs.Visible = true;
                //int requiredSkillId=Convert.ToInt32(((TextBox)row.FindControl("txtRequiredSkillId")).Text.Trim());
                int jobReqId = Convert.ToInt32(row.Cells[1].Text);
                DateTime latestBookingDate = Convert.ToDateTime(row.Cells[10].Text);
                Session.Add("jobReqId", jobReqId);
                //Assumption: coordinators can see the skill table and therefore they can choose the requiredskillId
                DataTable availableContractors = AvailableContractors.GetAllAvailableContractors(latestBookingDate);
                gvAvailableContractors.DataSource = availableContractors;
                gvAvailableContractors.DataBind();
                if(gvAvailableContractors.Rows.Count != 0) {
                gvAvailableContractors.HeaderRow.Cells[0].Text = "";
                gvAvailableContractors.HeaderRow.Cells[8].Visible = false;
                gvAvailableContractors.HeaderRow.Cells[9].Visible = false;
                gvAvailableContractors.HeaderRow.Cells[12].Visible = false;
                foreach (GridViewRow aRow in gvAvailableContractors.Rows)
                {
                    aRow.Cells[8].Visible = false;
                    aRow.Cells[9].Visible = false;
                    aRow.Cells[12].Visible = false;
                } }
                if(gvAvailableContractors.Rows.Count == 0)
                {
                    noAvailCont.Visible = true;
                }
            }
            }

        protected void gvAvailableContractors_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Confirm")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvAvailableContractors.Rows[rowIndex];
                string sql = "set dateformat dmy; update jobRequest set availabilityId = '" + Convert.ToInt32(row.Cells[9].Text) + "', staffId = '" + Session["staffId"].ToString() + "', statusId='0' where jobReqId = '" + Session["jobReqId"].ToString() + "'";

                SQLHelper helper = new SQLHelper();
                helper.ExecuteSQL(sql);
                string updatesql = "update Availability set status = 'NA' where availabilityId= " +
                    Convert.ToInt32(row.Cells[9].Text);
                helper.ExecuteNonQuery(updatesql);
                RefreshGrid();
            }
            gvAvailableContractors.DataSource = null;
            gvAvailableContractors.DataBind();
        }
    }
}