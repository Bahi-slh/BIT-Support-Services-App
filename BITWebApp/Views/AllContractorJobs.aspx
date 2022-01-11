<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllContractorJobs.aspx.cs" Inherits="BITWebApp.Views.AllContractorJobs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <div style="text-align:center; padding:20px">
                    <h4> All Booked jobs </h4>
                </div>
                <div style="text-align:center; padding:10px;font-weight:bold; color:blue" runat="server" id="noItems">
                    <h5> Currently there is no item to show!</h5>
                </div>
            </div>
         </div>
         <div class="row">
            <div class="col-12">
                <asp:GridView ID="gvBookedJobs"
                              CssClass="table table-striped table-bordered"
                              runat="server" OnRowCommand="gvBookedJobs_RowCommand" >
                 <Columns>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="txtAccept"
                                         runat="server" CommandName="Accept"
                                          Text="Accept"
                                         CssClass="btn btn-success btn-block btn-xs"
                                        CommandArgument="<%#Container.DataItemIndex %>"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                             <asp:Button ID="btnReject"
                             runat="server" CommandName="Reject"
                              Text="Reject"
                             CssClass="btn btn-danger btn-block btn-xs"
                            CommandArgument="<%#Container.DataItemIndex %>"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
                  </asp:GridView>
                </div>
            </div>
        </div>
</asp:Content>
