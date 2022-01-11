<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllJobs.aspx.cs" Inherits="BITWebApp.Views.AllJobs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
     <div class="container-fluid">
       <div class="row">
            <div  class="col-12">
                <div style="text-align:center; padding:20px">
                    <h4> Accepted Jobs</h4>
                </div>
                <div style="text-align:center; padding:10px;font-weight:bold; color:blue" runat="server" id="noItems">
                    <h5> Currently there is no item to show!</h5>
                </div>
              </div>
           </div>
        <div class="row"> 
                          <div class ="col-12"> 
                                  <asp:GridView ID="gvBookedJobs" AllowPaging="true" PageSize="10"
                                                CssClass="table table-striped table-bordered" 
                                                runat="server" />
                          </div>
        </div>
    </div>
</asp:Content>
