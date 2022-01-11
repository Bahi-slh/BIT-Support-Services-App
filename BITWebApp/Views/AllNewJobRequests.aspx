<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllNewJobRequests.aspx.cs" Inherits="BITWebApp.Views.AllNewJobRequests" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <div style="text-align:center; padding:20px" >
                    <h4> All New Job Requests </h4>
                 </div>
                <div style="text-align:center; padding:10px;font-weight:bold; color:blue" runat="server" id="nojobReq">
                    <h5> Currently there is no item to show!</h5>
                </div>
            </div>
         </div>
         <div class="row">
            <div class="col-12">
                <asp:GridView    ID="gvNewJobRequests"
                                 CssClass="table table-striped table-bordered"
                                 runat="server" 
                                 onRowCommand="gvNewJobRequests_RowCommand">
                    <Columns>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="btnFind"
                                         runat="server" CommandName="Find"
                                         Text="Find a Contractor"
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
                <div style="text-align:center; padding:20px" id="hAvailableContracs" runat="server">
                    <h4> Available Contractors</h4>
                 </div>
                <div style="text-align:center; padding:10px;font-weight:bold; color:blue" runat="server" id="noAvailCont">
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
                                          Text="Assign"
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
