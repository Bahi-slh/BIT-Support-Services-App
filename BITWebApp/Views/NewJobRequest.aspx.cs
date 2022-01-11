using BITWebApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BITWebApp
{
    public partial class NewJobRequest : System.Web.UI.Page //for client
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            TrueDynamicClientLinks();

        }

        protected void btnSubmitJobReq_Click(object sender, EventArgs e)
        {
            if (calBookDate.SelectedDate == null || txtSuburb.Text == ""  || txtDesc.Text == ""||ddlJobPriority.SelectedValue==null)
            {
                Response.Write("<script> alert('Enter date, time, lesson type and description of your request please!')</script>");
            }
            else
            {
                //bookingDate is actually the date that client wants the job booked.
                int clientId = Convert.ToInt32(Session["ClientId"]);
                
                string sql = "set dateformat dmy; insert into jobRequest(clientId, bookingDate, statusId, description, address, suburb, state, postcode, jobPriority) " +
                    " values(" + clientId + ", '" + calBookDate.SelectedDate + "', '5', '"+ txtDesc.Text +
                    "', '"+txtAddress.Text+"', '"+txtSuburb.Text+"', '"+ ddlState.SelectedValue+"', '"+ txtPostCode.Text+
                    "', '"+ddlJobPriority.SelectedValue+"') ";
                SQLHelper helper = new SQLHelper();
                
                helper.ExecuteSQL(sql);
                Response.Write("<script> alert('Your request was sent successfully!')</script>");
                Response.Redirect("AllClientJobs.aspx");
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