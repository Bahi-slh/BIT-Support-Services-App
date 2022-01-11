<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllRejectedJobs.aspx.cs" Inherits="BITWebApp.Views.AllRejectedJobs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <div style="text-align:center; padding:20px">
                    <h4> All Rejected Jobs </h4>
                 </div>
                <div style="text-align:center; padding:10px;font-weight:bold; color:blue" runat="server" id="noRejectedJobs">
                    <h5> Currently there is no item to show!</h5>
                </div>
            </div>
         </div>
         <div class="row">
            <div class="col-12">
                <asp:GridView    ID="gvRejectedJobs"
                                 CssClass="table table-striped table-bordered"
                                 runat="server" 
                                 onRowCommand="gvRejectedJobs_RowCommand">
                    <Columns>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="btnFind"
                                         runat="server" CommandName="Find"
                                          Text="Re-Assign"
                                         CssClass="btn btn-primary btn-block btn-xs"
                                        CommandArgument="<%#Container.DataItemIndex %>"
                                 />
                        </ItemTemplate>
                    </asp:TemplateField>
                        </Columns>
                </asp:GridView>
                </div>
             </div>

        <div class="row">
            <div class="col-12">
                <div style="text-align:center; padding:20px" runat="server" id="otherContacs">
                    <h4> Other Available Contractors</h4>
                 </div>
                <div style="text-align:center; padding:10px;font-weight:bold; color:blue" runat="server" id="noContItems">
                    <h5> Currently there is no item to show!</h5>
                </div>
            </div>
         </div>
         <div class="row">
            <div class="col-12">
                <asp:GridView    ID="gvAvailableContractors"
                                 CssClass="table table-striped table-bordered"
                                 runat="server"
                    OnRowCommand="gvAvailableContractors_RowCommand">
                    <Columns>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="btnConfirm"
                                         runat="server" CommandName="Confirm"
                                          Text="Confirm"
                                         CssClass="btn btn-success btn-block btn-xs"
                                        CommandArgument="<%#Container.DataItemIndex %>"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                        </Columns>
                </asp:GridView>
                </div>
             </div>
        </div>
</asp:Content>
