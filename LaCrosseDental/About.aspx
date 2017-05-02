<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="LaCrosseDental.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%: Title %>.</h1>
    <h2>Understanding This Website- about what you can do on this website</h2>
    <p><br></p>
    <h3>Welcome Page</h3>
    <p><br></p>
    <img src="Welcome.png" alt="Welcome page" style="width:973px;height:730px;">
    <p><br><br></p>
    <p style="font-size:30px">This is the Home Page that comes up when you first enter this website.  From this page, you can navigate to pages that will help you log in, register, or contact us.<br><br><br></p>
    <img src="WelcomeContact.png" alt="Welcome page contact link" style="width:973px;height:730px;">
    <p><br><br></p>
    <p style="font-size:30px">You can click on this tab to be directed to the contact page where you will fill out the form to contact us.<br><br><br></p>
    <img src="WelcomeLogin.png" alt="Welcome page login links" style="width:973px;height:730px;">
    <p><br><br></p>
    <p style="font-size:30px">Click on either the large button or the tab in the right corner to be directed to the login page.<br><br><br></p>
    <img src="WelcomeRegister.png" alt="Welcome page register" style="width:973px;height:730px;">
    <p><br><br></p>
    
    <p style="font-size:30px">Click on either the large button or the tab in the right corner to be directed to the page for registration.<br><br><br><br><br></p>
   
    <h3>Login Page</h3>
    <p><br></p>
    <img src="Login.png" alt="Login Page" style="width:973px;height:730px;">
    <p><br><br></p>
    
    <p style="font-size:30px">This is the login page.  Enter both your email and password, click the check box to be remembered, and click the login button to submit the form. <br><br><br> </p>
   
    <img src="LoginRegister.png" alt="Login register link" style="width:973px;height:730px;">
    <p><br><br></p>
    
    <p style="font-size:30px">If you do not have an account, please register as a new user with this link.<br><br><br><br><br></p>
    
    <h3>Registration Page</h3>
    <p><br></p>
    <img src="Register.png" alt="Register" style="width:973px;height:730px;">
    <p><br><br></p>
    
    <p style="font-size:30px">Use this form to register as a user.  Enter your email, enter your password, type your password again, and enter your name before clicking the button to submit the form.  All of this information is required.  Make sure the password typed is the same in both boxes, otherwise there will be an error. <br><br><br><br><br></p>
   
    <h3>Patient Home Page</h3>
    <p><br></p>
    <img src="PatientHome.png" alt="Patient home" style="width:973px;height:730px;">
    <p><br><br></p>
    
    <p style="font-size:30px">This is the home page for a patient.  From here, if you are an employee, you can be redirected to view your appointments, manage your password, log off, view your calendar, or schedule an appointment.<br><br><br><br><br></p>
    
    <h3>Patient Appointment Page</h3>
    <p><br></p>
    <img src="PatientAppt.png" alt="patient appointments" style="width:973px;height:730px;">
    <p><br><br></p>
   
    <p>This is the page to request an appointment at the dental office.  You must select a day for your appointment, an appointment type, and a time for your appointment.  Click the submit button to send the form and wait for approval.<br><br><br><br><br></p>
    
    <h3>Employee Home Page</h3>
    <p><br></p>
    <img src="DoctorHome.png" alt="employee page" style="width:973px;height:730px;">
    <p><br><br></p>
    
    <p style="font-size:30px">This is the home page for an employee of the dental agency.  From here, if you are an employee, you can be redirected to the page to manage your schedule, the page to view your schedule, view your calendar, manage your own password, or log off.<br><br><br><br><br></p>
   
    <h3>Admin Home Page</h3>
    <p><br></p>
    <img src="AdminHome.png" alt="admin page" style="width:973px;height:730px;">
    <p><br><br></p>
    
    <p style="font-size:30px">This is the home page for the administrator of the website.  From here you can view the appointments, manage users, manage appointments, log off, or manage your password.<br><br><br><br><br></p>
    
    <h3>Admin Manage Appointments Page</h3>
    <p><br></p>
    <img src="ManageAppt.png" alt="manageappt" style="width:973px;height:730px;">
    <p><br><br></p>
    
    <p style="font-size:30px">This is the page for managing appointments.  To approve an appointment, click on the appointment to approve and assign a doctor and hygienist to the appointment before clicking submit.<br><br><br><br><br></p>
    <h3>Manage User Pages</h3>
    <p><br></p>
    <img src="ManageEdit.png" alt="edit users page" style="width:973px;height:730px;">
    <p><br><br></p>
    <p style="font-size:30px">This is where users can be editted.  After choosing a user to edit, the fields will fill automatically and can be changed.<br><br><br><br><br></p>
    <img src="ManageCreate.png" alt="create user page" style="width:973px;height:730px;">
    <p><br><br></p>
    <p style="font-size:30px">This is where a user can be created.  Fill out all fields before clicking submit.<br><br><br><br><br></p>
    <img src="ManageDeactivate.png" alt="deactivate user page" style="width:973px;height:730px;">
    <p><br><br></p>
    <p style="font-size:30px">This is where a user can be deactivated.  Choose the user to deactivate and then submit.</p>
</asp:Content>
