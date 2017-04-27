﻿<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="LaCrosseDental.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Understanding This Website- about what you can do on this website</h3>
    <p></p>
    <h4>Welcome Page</h4>
    <img src="Welcome.png" alt="Welcome page" style="width:1216px;height:912px;">
    <p></p>
    <p>This is the Home Page that comes up when you first enter this website.  From this page, you can navigate to pages that will help you log in, register, or contact us.</p>
    <img src="WelcomeContact.png" alt="Welcome page contact link" style="width:1216px;height:912px;">
    <p></p>
    <p>You can click on this tab to be directed to the contact page where you will fill out the form to contact us.</p>
    <img src="WelcomeLogin.png" alt="Welcome page login links" style="width:1216px;height:912px;">
    <p></p>
    <p>Click on either the large button or the tab in the right corner to be directed to the login page.</p>
    <img src="WelcomeRegister.png" alt="Welcome page register" style="width:1216px;height:912px;">
    <p></p>
    <p>Click on either the large button or the tab in the right corner to be directed to the page for registration.</p>
    <p></p>
    <h4>Login Page</h4>
    <img src="Login.png" alt="Login Page" style="width:1216px;height:912px;">
    <p></p>
    <p>This is the login page.  Enter both your email and password, click the check box to be remembered, and click the login button to submit the form.  </p>
    <img src="LoginRegister.png" alt="Login register link" style="width:1216px;height:912px;">
    <p></p>
    <p>If you do not have an account, please register as a new user with this link.</p>
    <p></p>
    <h4>Registration Page</h4>
    <img src="Register.png" alt="Register" style="width:1216px;height:912px;">
    <p></p>
    <p>Use this form to register as a user.  Enter your email, enter your password, type your password again, and enter your name before clicking the button to submit the form.  All of this information is required.  Make sure the password typed is the same in both boxes, otherwise there will be an error. </p>
    <p></p>
    <h4>Patient Home Page</h4>
    <img src="PatientHome.png" alt="Patient home" style="width:1216px;height:912px;">
    <p></p>
    <p>This is the home page for a patient.  From here, if you are an employee, you can be redirected to view your appointments, manage your password, log off, view your calendar, or schedule an appointment.</p>
    <p></p>
    <h4>Patient Appointment Page</h4>
    <img src="PatientAppt.png" alt="patient appointments" style="width:1216px;height:912px;">
    <p></p>
    <p>This is the page to request an appointment at the dental office.  You must select a day for your appointment, an appointment type, and a time for your appointment.  Click the submit button to send the form and wait for approval.</p>
    <p></p>
    <h4>Employee Home Page</h4>
    <img src="DoctorHome.png" alt="employee page" style="width:1216px;height:912px;">
    <p></p>
    <p>This is the home page for an employee of the dental agency.  From here, if you are an employee, you can be redirected to the page to manage your schedule, the page to view your schedule, view your calendar, manage your own password, or log off.</p>
    <p></p>
    <h4>Admin Home Page</h4>
    <img src="AdminHome.png" alt="admin page" style="width:1216px;height:912px;">
    <p></p>
    <p>This is the home page for the administrator of the website.  From here you can view the appointments, manage users, manage appointments, log off, or manage your password.</p>
    <p></p>
    <h4>Admin Manage Appointments Page</h4>
    <img src="ManageAppt.png" alt="manageappt" style="width:1216px;height:912px;">
    <p></p>
    <p>This is the page for managing appointments.  To approve an appointment, click on the appointment to approve and assign a doctor and hygienist to the appointment before clicking submit.</p>
    <p></p>
</asp:Content>
