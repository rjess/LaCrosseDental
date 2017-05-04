<!--This  is the manage users page when on the La Crosse Dental Website-->
<%@ Page Title="Manage Users" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="LaCrosseDental.ManageUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>
    <div class="form-horizontal">
        <h4>Edit Account</h4>
        <hr />
        <div class="form-group" runat="server">
            <label class="col-lg-1 control-label"></label>
            <div class="col-lg-10">
                <asp:RadioButtonList ID="RadioList" runat="server" Height="69px" Width="156px" CssClass="radio"
                     OnSelectedIndexChange="RadioSelection" AutoPostBack="true">
                    <asp:ListItem>Edit User</asp:ListItem>
                    <asp:ListItem>Create User</asp:ListItem>
                    <asp:ListItem>Deactivate User</asp:ListItem>
                </asp:RadioButtonList>
            </div>
        </div>
        <div class="form-group" runat="server" id="userSelectGroup">
            <label for="select" class="col-lg-2 control-label">Choose User</label>
            <div class="col-lg-10">
                <asp:DropDownList ID="userSelect" runat="server" CssClass="form-control" OnSelectedIndexChanged="UpdateFields" 
                    AutoPostBack="true" visible="true">
                </asp:DropDownList>
            </div>
        </div>
        <br />
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group" runat="server" ID="NameGroup">
            <asp:Label runat="server" AssociatedControlID="Name" CssClass="col-md-2 control-label">Name</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Name" CssClass="form-control" visible="true"/>
            </div>
        </div>
        <div class="form-group" runat="server" ID="UsernameGroup">
            <asp:Label runat="server" AssociatedControlID="Username" CssClass="col-md-2 control-label">Username</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Username" CssClass="form-control" visible="true"/>
            </div>
        </div>
        <div class="form-group" runat="server" ID="PasswordGroup">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" CssClass="form-control" TextMode="Password"/>
            </div>
        </div>
        <div class="form-group" runat="server" ID="EmailGroup">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" visible="true"/>
            </div>
        </div>
        <div class="form-group" runat="server" ID="UserTypeGroup">
            <asp:Label runat="server" AssociatedControlID="UserType" CssClass="col-md-2 control-label">Type</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="UserType" CssClass="form-control" visible="true"/>
            </div>
        </div>
        <div class="form-group" runat="server">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="SubmitEdit" Text="Submit" CssClass="btn btn-primary" Height="46px" Width="128px" />
                <asp:Button runat="server" OnClick="Cancel_Click" Text="Cancel" CssClass="btn btn-default" Height="46px" Width="128px" />
            </div>
        </div>
    </div>
</asp:Content>
