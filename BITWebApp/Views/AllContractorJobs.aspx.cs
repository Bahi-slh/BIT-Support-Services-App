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
    public partial class AllContractorJobs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //IsPostBack is a property of the Asp.Net page that tells whether or not the page is on its initial load or if a user has perform a button on your web page that has caused the page to post back to itself.The value of the Page.IsPostBack property will be set to true when the page is executing after a postback, and false otherwise.We can check the value of this property based on the value and we can populate the controls on the page.
            if (!IsPostBack)
            {
                if (Session["contractorId"] != null)
                {
                    LinkButton acceptedjobReqsLink = (LinkButton)this.Master.FindControl("lbtnAcceptedjobReqs");
                    acceptedjobReqsLink.Visible = true;

                    LinkButton assignedJobsLink = (LinkButton)this.Master.FindControl("lbtnAssignedJobs");
                    assignedJobsLink.Visible = false;

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
            ContractorJobRequests allBookings = new ContractorJobRequests(contractorId);
            DataTable bookingsDT = ToDataTable<ContractorJobRequest>(allBookings);
            
            gvBookedJobs.DataSource = bookingsDT;
            gvBookedJobs.DataBind();
            if (bookingsDT.Rows.Count != 0) { 
            gvBookedJobs.HeaderRow.Cells[0].Text = "";
            gvBookedJobs.HeaderRow.Cells[1].Text = "";
            gvBookedJobs.HeaderRow.Cells[2].Visible = false;
            gvBookedJobs.HeaderRow.Cells[3].Visible = false;
            gvBookedJobs.HeaderRow.Cells[4].Visible = false;
            gvBookedJobs.HeaderRow.Cells[5].Text = "Client's Firstname";
            gvBookedJobs.HeaderRow.Cells[6].Text = "Client's Lastname";
            gvBookedJobs.HeaderRow.Cells[7].Text = "Address";
            gvBookedJobs.HeaderRow.Cells[8].Text = "Suburb";
            gvBookedJobs.HeaderRow.Cells[9].Text = "State";
            gvBookedJobs.HeaderRow.Cells[10].Text = "Postcode";
            gvBookedJobs.HeaderRow.Cells[11].Text = "Booked Date";
            gvBookedJobs.HeaderRow.Cells[12].Text = "Start Time";
            foreach (GridViewRow row in gvBookedJobs.Rows)
            {
                row.Cells[2].Visible = false;
                row.Cells[3].Visible = false;
                row.Cells[4].Visible = false;

            }}
            if (bookingsDT.Rows.Count == 0)
            {
                noItems.Visible = true;
            }
        }
        //for binding purpose( bindes object of contractorJobRequest to the table)
        public DataTable ToDataTable<ContractorJobRequest>(List<ContractorJobRequest> items)
        {
            DataTable dataTable = new DataTable(typeof(ContractorJobRequest).Name);

            //data structure convertion happens here
            PropertyInfo[] props = typeof(ContractorJobRequest).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in props)
            {
                dataTable.Columns.Add(prop.Name);
            }
            foreach (ContractorJobRequest item in items)
            {
                var values = new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        protected void gvBookedJobs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ContractorJobRequest booking = new ContractorJobRequest();
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvBookedJobs.Rows[rowIndex];
            if (e.CommandName == "Accept")
            {
                booking.AcceptedJob(Convert.ToInt32(row.Cells[2].Text));
                RefreshGrid();
            }
            else if (e.CommandName == "Reject")
            {
                booking.RejectedJob(Convert.ToInt32(row.Cells[2].Text));
                RefreshGrid();
            }
        }
    }
}