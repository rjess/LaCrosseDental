<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageSchedule.aspx.cs" Inherits="LaCrosseDental.ManageSchedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
    <legend><br />Manage Your Schedule</legend>
    <div class="form-group">
        <label for="list" class="col-lg-2 control-label">Your Appointments</label>
        <div class="col-lg-10">
            <asp:ListBox ID="Appointments" runat="server" Height="160px" Width="450px" SelectionMode="Single" BorderStyle="Solid" 
                Font-Bold="True" Font-Size="14pt" BackColor="WhiteSmoke">
            </asp:ListBox>
        </div>
    </div>
    <div class="form-group">
        <div class="col-lg-10 col-lg-offset-2">
        <br />
            <asp:Button ID="Cancel" runat="server" Height="43px" Text="Cancel Appointment" Width="147px" 
                OnClick="Submit_Click" CssClass="btn btn-primary"/>
            <asp:Button runat="server" Text="Exit" OnClick="Back_Click" CssClass="btn btn-default"
                Height="43px" Width="147px"/>
        </div>
    </div>
    </fieldset>
</asp:Content>
