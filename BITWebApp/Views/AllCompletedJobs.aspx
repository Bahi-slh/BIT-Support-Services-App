<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllCompletedJobs.aspx.cs" Inherits="BITWebApp.Views.AllCompletedJobs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
     <div class="container-fluid">
       <div class="row">
            <div  class="col-12">
                <div style="text-align:center; padding:20px">
                    <h4>Completed Jobs</h4>
                </div>
              </div>
           </div>
        <div class="row"> 
                          <div class ="col-12"> 
                                  <asp:GridView ID="gvCompletedJobs" 
                                                AllowPaging="true" 
                                                PageSize="10"
                                                CssClass="table table-striped table-bordered"
                                                runat="server"
                                                onRowCommand="gvCompletedJobs_RowCommand">
                                      <Columns>
                                          <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="btnVerify"
                                         runat="server" CommandName="Verify"
                                         Text="Sent for payment"
                                         CssClass="btn btn-success btn-block btn-xs"
                                        CommandArgument="<%#Container.DataItemIndex %>"
                                 />
                        </ItemTemplate>
                    </asp:TemplateField>
                                      </Columns>
                                  </asp:GridView>
                          </div>
        </div>
    </div>
</asp:Content>
