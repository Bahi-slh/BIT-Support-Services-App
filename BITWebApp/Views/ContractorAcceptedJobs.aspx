<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ContractorAcceptedJobs.aspx.cs" Inherits="BITWebApp.Views.ContractorAcceptedJobs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <div style="text-align:center; padding:20px">
                    <h4> All Accepted Job Requests </h4>
                 </div>
                <div style="text-align:center; padding:10px;font-weight:bold; color:blue" runat="server" id="noItems">
                    <h5> Currently there is no item to show!</h5>
                </div>
            </div>
         </div>
         <div class="row">
            <div class="col-12">
                <asp:GridView    ID="gvAcceptedJobs"
                                 CssClass="table table-striped table-bordered"
                                 runat="server" OnRowCommand="gvAcceptedJobs_RowCommand" >
                    <Columns>
                        <asp:TemplateField HeaderText="distance driven">
                            <ItemTemplate>
                                <asp:TextBox ID="txtKmsDriven"
                                             runat="server" CommandName="KmsDriven"
                                             Height="40px" PlaceHolder="in Kms"
                                             Width="80px"
                                            CommandArgument="<%#Container.DataItemIndex %>"/>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Job Duration">
                            <ItemTemplate>
                                <asp:TextBox ID="txtJobDuration"
                                             runat="server" CommandName="jobDuration"
                                             Height="40px" PlaceHolder="in hours"
                                             Width="80px"
                                            CommandArgument="<%#Container.DataItemIndex %>"/>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Feedback">
                            <ItemTemplate>
                                <asp:TextBox ID="txtFeedback"
                                             runat="server" CommandName="Feedback"
                                             Height="40px" PlaceHolder="feedback"
                                             Width="80px"
                                            CommandArgument="<%#Container.DataItemIndex %>"/>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:Button  ID="btnComplete"
                                             runat="server" CommandName="Complete"
                                              Text="Complete"
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
