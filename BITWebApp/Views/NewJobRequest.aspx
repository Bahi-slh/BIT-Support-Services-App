<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewJobRequest.aspx.cs" Inherits="BITWebApp.NewJobRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <div class="container-fluid">
        <br />
        <div class="row">
            <div class="col-md-8 mx-auto">
                <div class="card">
                 <div class="card-body">

                     <div class="row">
                        <div class="col">
                            <center>
                                <img src="/Images/request-icon.png" width="100px" />
                            </center>
                        </div>
                    </div>

                     <div class="row">
                        <div class="col">
                            <center>
                                <h3> New Job Request</h3>
                            </center>
                        </div>
                    </div>

                     <div class="row">
                            <div class="col">
                                 <label>Address Line (Example: 3 George Street)</label>
                                 <div class="form-group">
                                 <asp:TextBox CssClass="form-control" ID="txtAddress"
                                runat="server" placeholder="Street"></asp:TextBox>

                                 </div>
                                 </div>
                     </div>

                     <div class="row">
                            <div class="col-md-4">
                                 <label>Suburb</label>
                                 <div class="form-group">
                                 <asp:TextBox CssClass="form-control" ID="txtSuburb"
                                runat="server" placeholder="Suburb"></asp:TextBox>

                                 </div>
                                 </div>
                     

                     
                            <div class="col-md-4">
                                 <label>Postcode</label>
                                 <div class="form-group">
                                 <asp:TextBox CssClass="form-control" ID="txtPostCode"
                                runat="server" placeholder="Postcode"></asp:TextBox>

                                 </div>
                                 </div>

                         <div class="col-md-4">
                                 <label>State</label>
                                     <div class="form-group">
                                     <asp:DropDownList class="form-control" ID="ddlState"
                                    runat="server">
                                     <asp:ListItem Text="Select" Value="select" />
                                     <asp:ListItem Text="NSW" Value="NSW" />
                                     <asp:ListItem Text="ACT" Value="ACT" />
                                     <asp:ListItem Text="WA" Value="WA" />
                                     <asp:ListItem Text="QLD" Value="QLD" />
                                     <asp:ListItem Text="TAS" Value="TAS" />
                                     <asp:ListItem Text="NT" Value="NT" />
                                     <asp:ListItem Text="VIC" Value="VIC" />
                                     <asp:ListItem Text="SA" Value="SA" />

                                     </asp:DropDownList>
                                 </div>
                                 </div>
                         </div>

                     <div class="row">
                          <%--  <div class="col-md-6">
                                 <label> Time</label>
                                 <div class="form-group">
                                <asp:DropDownList CssClass="form-control" ID="ddlStartTime"  
                                        runat="server"> 
                                        <asp:ListItem Text="Select" Value="select" /> 
                                        <asp:ListItem Text="9:00AM" Value="9:00:00" /> 
                                        <asp:ListItem Text="10:00AM" Value="10:00:00" /> 
                                        <asp:ListItem Text="11:00AM" Value="11:00:00" /> 
                                        <asp:ListItem Text="12:00PM" Value="12:00:00" /> 
                                        <asp:ListItem Text="01:00PM" Value="13:00:00" /> 
                                        <asp:ListItem Text="02:00PM" Value="14:00:00" /> 
                                        <asp:ListItem Text="03:00PM" Value="15:00:00" /> 
                                        <asp:ListItem Text="04:00PM" Value="16:00:00" />                                         
                                    </asp:DropDownList> 
                                

                                 </div>
                                 </div>--%>

                         
                     <div class="col-md-8">
                         <label>Description (What is your ICT job request?)</label>
                         <div class="form-group">
                         <asp:TextBox CssClass="form-control" ID="txtDesc"
                                runat="server" placeholder="Description"></asp:TextBox>
                         </div>
                         </div>
                    <div class="col-md-4">
                         <label>Job Priority:</label>
                         <div class="form-group">
                         <asp:DropDownList CssClass="form-control" ID="ddlJobPriority"
                                runat="server" placeholder="Description">
                                        <asp:ListItem Text="Low" Value="Low" /> 
                                        <asp:ListItem Text="Medium" Value="Medium" /> 
                                        <asp:ListItem Text="High" Value="High" /> 
                         </asp:DropDownList>
                         </div>
                         </div>
                         
                     </div>
                    
                     <div class="row">
                     <div class="col-md-6">
                         <label>Lastest Booking Date</label>
                         <div class="form-group">
                         <asp:Calendar ID="calBookDate" runat="server"> </asp:Calendar> 
                         </div>
                         </div>
                         </div>

                     <div class="row"> 
                            <div class="col-12 mx-auto"> 
                                <div style="text-align:center"> 
                                    <asp:Button CssClass="btn btn-success btn-block btn-lg" 
                                        ID="btnSubmitJobReq" runat="server"  
                                        Text ="Submit"  
                                        onClick="btnSubmitJobReq_Click"
                                        /> 
                                </div> 
                            </div> 
                        </div>

                     
                
            </div>
            </div>
            </div>
        </div>
    </div>
</asp:Content>
