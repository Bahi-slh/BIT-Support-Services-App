using BITWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BITWebApp
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UserLogin userLogin = new UserLogin()
            {
                UserName = txtUsername.Text,
                Password = txtPassword.Text
            };

            if (userLogin.IsClient())
            {
                int clientId = userLogin.UserId;
                Session.Add("ClientId", clientId);
                Response.Redirect("AllClientJobs.aspx?clientId="+clientId); 

            }
            else if (userLogin.IsContractor())
            {
                int contractorId = userLogin.UserId;
                Session.Add("contractorId", contractorId);
                Response.Redirect("AllContractorJobs.aspx?contractorId=" + contractorId);

            }
            else if (userLogin.IsStaff())
            {
                int staffId = userLogin.UserId;
                Session.Add("staffId", staffId);
                //this will be all accepted bookings and we will have another page that will handle the rebookings for rejected sessions.
                //In BIT services your staff is required to re-assign a contractor to a Rejected Job, and remember when re-assigning a new contractor the same contractor who has rejected the job earlier must not come in the search list.
                //its a functionality that is required and is being marked.
                Response.Redirect("AllJobs.aspx?staffId=" + staffId);

            }
            else
            {
                Response.Write("Username or password are incorrect, try again!");
            }
        }
    }
}