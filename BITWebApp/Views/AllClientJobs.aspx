<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllClientJobs.aspx.cs" Inherits="BITWebApp.Views.AllClientJobs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <div class="container-fluid">
       <div class="row">
            <div  class="col-12">
                <div style="text-align:center">
                    <h4 class="tableTitle"> All Job Requests</h4>
                </div>
                <div style="text-align:center; padding:10px;font-weight:bold; color:blue" runat="server" id="noHistory">
                    <h5> Currently there is no item to show!</h5>
                </div>
              </div>
           </div>
        <div class="row"> 
                          <div class ="col-12"> 
                                  <asp:GridView ID="gvJobRequests" 
                                                CssClass="table table-striped table-bordered" 
                                                runat="server" 
                                      />
                          </div>
        </div>




         <div class="row">
            <div  class="col-12">
                <div style="text-align:center">
                    <h4 class="tableTitle">Job Requests Waiting to be assigned</h4>
                </div>
                <div style="text-align:center; padding:10px;font-weight:bold; color:blue" runat="server" id="noItems">
                    <h5> Currently there is no item to show!</h5>
                </div>
              </div>
           </div>
        <div class="row"> 
                          <div class ="col-12"> 
                                  <asp:GridView ID="gvJobsNotAssignedYet" 
                                                CssClass="table table-striped table-bordered" 
                                                runat="server" />
                              
                          </div>
        </div>
    </div>
</asp:Content>
