<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="BITWebApp.homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <section>
        <img src="/Images/cover-homepage.png" class="img-fluid" />
    </section>

    <section>
        <div class="row" style="background-color:#afc7b7">
            <div style="background-color:white; margin:3% 10% 3% 10%; padding:2%">
            <center>
                <h1 style="color:#26783b; padding: 10px 0px 10px">Our IT Services</h1>
                <h5>BIT field support services is a division of Business Information Technology Pty Ltd (BIT) that provides IT support services (hardware and software trouble-shooting, new installations, periodic IT audits, etc) for approximately 2,500 clients in Australia!</h5>
                <h4 style="padding-top:10px">Schedule a meeting for any IT services <a href="Login.aspx" class="link-info">HERE !</a></h4>
            </center>

            </div>
        </div>
    </section>

    

</asp:Content>
