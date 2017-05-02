<!--This  is the contact page when on the La Crosse Dental Website-->
<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="LaCrosseDental.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Contact Us!</h3>
    <address>
        101 Healthy Smiles Ln<br />
        LaCrosse, WI 54601<br />
        <abbr title="Phone">P:</abbr>
        608-738-6056
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:LDHelp@lacrossedental.com">LDHelp@lacrossedental.com</a><br />
    </address>
</asp:Content>
