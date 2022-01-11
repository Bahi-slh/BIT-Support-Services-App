using BITWebApp.DAL;
using BITWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BITWebApp.Views
{
    public partial class AllRejectedJobs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // the statement (!IsPostBack) means that the page loads for the firstTime
            if (!IsPostBack)
            {
                if (Session["staffId"] != null)
                {
                    //LinkButton allNewJobReqsLink = (LinkButton)this.Master.FindControl("lbtnAllNewJobRequests");
                    //allNewJobReqsLink.Visible = true;
                    LinkButton allNewJobReqsLink = (LinkButton)this.Master.FindControl("lbtnNewJobRequests");
                    allNewJobReqsLink.Visible = true;

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
            otherContacs.Visible = false;
            noContItems.Visible = false;
            noRejectedJobs.Visible = false;
            RejectedJobs allJobs = new RejectedJobs();
            gvRejectedJobs.DataSource = allJobs.AllRejectedJobs().DefaultView;
            gvRejectedJobs.DataBind();
            if (gvRejectedJobs.Rows.Count != 0)
            {
                gvRejectedJobs.HeaderRow.Cells[0].Text = "";
                gvRejectedJobs.HeaderRow.Cells[1].Visible = false;
                gvRejectedJobs.HeaderRow.Cells[2].Visible = false;
                gvRejectedJobs.HeaderRow.Cells[5].Visible = false;
                foreach (GridViewRow row in gvRejectedJobs.Rows)
                {
                    row.Cells[1].Visible = false;
                    row.Cells[2].Visible = false;
                    row.Cells[5].Visible = false;

                }
            }
            if (gvRejectedJobs.Rows.Count == 0)
            {
                noRejectedJobs.Visible = true;
            }
        }

        
 

        public void gvRejectedJobs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvRejectedJobs.Rows[rowIndex];
            if (e.CommandName == "Find") {
                otherContacs.Visible = true;
                int jobReqId= Convert.ToInt32(row.Cells[1].Text);
                //DateTime availDate = Convert.ToDateTime(row.Cells[12].Text);
                //    DateTime bookingDate = Convert.ToDateTime(row.Cells[14].Text);
                //string startTime = row.Cells[13].Text;
                DateTime bookingDate = Convert.ToDateTime(row.Cells[12].Text);

                //    string suburb = row.Cells[9].Text;
                //    string jobDesc = row.Cells[6].Text;
               // string requiredSkill = row.Cells[15].Text;

                //    int clientId = Convert.ToInt32(row.Cells[5].Text);
                //    string address = row.Cells[8].Text;
                //    string state = row.Cells[10].Text;
                //    string postcode = row.Cells[11].Text;
                //    Session.Add("clientId", clientId);
                //    Session.Add("suburb", suburb);
                //    Session.Add("address", address);
                //Session.Add("startTime", startTime);
                Session.Add("bookingDate", bookingDate);
                Session.Add("jobReqId", jobReqId);
                    //    //8 and 9
                    //    Session.Add("state", state);
                    //    Session.Add("postcode", postcode);
                    //    Session.Add("description", jobDesc);
                    //    Session.Add("bookingDate", bookingDate);

                    //    //create session variables for pickupAddress, pickupSuburb, postcode, state, licencecategoryId
                   // DataTable availableContractors = AvailableContractors.GetAllAvailableContractors(availDate, startTime, requiredSkill);
                    DataTable availableContractors = AvailableContractors.GetAllAvailableContractors(bookingDate);
                    gvAvailableContractors.DataSource = availableContractors;
                    gvAvailableContractors.DataBind();
                if (gvAvailableContractors.Rows.Count != 0)
                {
                    gvAvailableContractors.HeaderRow.Cells[0].Text = "";
                    gvAvailableContractors.HeaderRow.Cells[8].Visible = false;
                    gvAvailableContractors.HeaderRow.Cells[9].Visible = false;
                    gvAvailableContractors.HeaderRow.Cells[12].Visible = false;

                    foreach (GridViewRow aRow in gvAvailableContractors.Rows)
                    {
                        aRow.Cells[8].Visible = false;
                        aRow.Cells[9].Visible = false;
                        aRow.Cells[12].Visible = false;


                    }
                }
                if (gvAvailableContractors.Rows.Count == 0) 
                {
                    noContItems.Visible = true;
                }

            }
        }


        protected void gvAvailableContractors_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Confirm")
            {
                //In future we will be using session variables to test if the page should be accessible at the first point or not

                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvAvailableContractors.Rows[rowIndex];
                string sql = "set dateformat dmy; update jobRequest set availabilityId = '" + Convert.ToInt32(row.Cells[9].Text) + "', staffId = '" + Session["staffId"].ToString() + "', statusId='0' where jobReqId = '" + Session["jobReqId"].ToString() + "'";


                //string sqll = "set dateformat dmy; insert into jobrequest(availabilityId, clientId, address, suburb, postCode, state, statusId, staffId , bookingDate) " +
                //    " values(" + Convert.ToInt32(row.Cells[3].Text) + " , " + Convert.ToInt32(Session["clientId"]) + ", " +
                //    " '" + Session["address"].ToString() + "', '" + Session["suburb"].ToString() + "', '" + Session["postcode"].ToString() +
                //    "', '" + Session["state"].ToString() + "', '0', '" + Session["staffId"].ToString() +
                //    "', '" + Session["bookingDate"] + "')";

                SQLHelper helper = new SQLHelper();
                //After we have used all these session variables
                //We then destroy them here itself.
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