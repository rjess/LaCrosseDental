<!--This  is the default page when on the La Crosse Dental Website-->
<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LaCrosseDental._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Welcome to La Crosse Dental!
        </h1>
        <p class="lead">We provide quick and convenient services for scheduling employees and managing appointments</p>
    </div>
    
    <div class="container">
        <ul class="nav nav-pills nav-stacked">
           <li class="active"><a runat="server" href="~/ManageUsers" visible="false" id="ad1">Manage Users</a></li>
           <li class="active"><a runat="server" href="~/ManageAppointments" visible="false" id="ad2">Manage Appointments</a></li>
           <li class="active"><a runat="server" href="~/ViewAppointments" visible="false" id="ad3">View All Appointments</a></li> 
        </ul>
        <ul class="nav nav-pills nav-stacked">
           <li class="active"><a runat="server" href="~/ViewAppointments" visible="false" id="u1">View Schedule</a></li>
           <li class="active"><a runat="server" href="#" visible="false" id="u2">Manage Schedule</a></li>
           <li class="active"><a runat="server" href="#" visible="false" id="u3">Calendar View</a></li> 
        </ul>
        <ul class="nav nav-pills nav-stacked">
           <li class="active"><a runat="server" href="~/ViewAppointments" visible="false" id="p1">View Current Appointments</a></li>
           <li class="active"><a runat="server" href="~/RequestAppointment" visible="false" id="p2">Schedule an Appointment</a></li>
           <li class="active"><a runat="server" href="#" visible="false" id="p3">Calendar View</a></li> 
        </ul>
        <a runat="server" href="~/Account/Login.aspx" class="btn btn-primary btn-lg" visible="false" id="logB">Please Log In to Continue</a>
        <a runat="server" href="~/Account/Register.aspx" class="btn btn-primary btn-lg" visible="false" id="regB">Or Register as a New User</a>
    </div>

</asp:Content>

