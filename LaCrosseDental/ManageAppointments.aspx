<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageAppointments.aspx.cs" Inherits="LaCrosseDental.ManageAppointments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        #bodycontent label { margin-bottom: 20px; }
    </style>
    <fieldset>
    <legend><br /><b>Approve Appointments</b></legend>
    <div class="form-group">
        <label for="ListBox1" class="col-lg-2 control-label">Unconfirmed Appointments</label>
        <div class="col-lg-10">
            <asp:ListBox ID="ListBox1" runat="server" Height="160px" Width="450px" SelectionMode="Single"
                  BorderStyle="Solid" Font-Bold="True" Font-Size="14pt" BackColor="WhiteSmoke">
            </asp:ListBox>
        </div>
    </div>
    <div class="form-group" runat="server">
        <label for="docSelect" class="col-lg-2 control-label"><br />Choose Doctor</label>
        <div class="col-lg-10">
            <br />
            <asp:DropDownList ID="docSelect" runat="server" CssClass="form-control" OnSelectedIndexChanged="CheckDoc" 
                AutoPostBack="true" visible="true">
            </asp:DropDownList>
        </div>
    </div>
    <div class="form-group" runat="server">
        <label for="hygSelect" class="col-lg-2 control-label"><br />Choose Hygienist</label>
        <div class="col-lg-10">
            <br />
            <asp:DropDownList ID="hygSelect" runat="server" CssClass="form-control" OnSelectedIndexChanged="CheckHyg" 
                AutoPostBack="true" visible="true">
            </asp:DropDownList>
        </div>
    </div>
    <div class="form-group">
        <div class="col-lg-10 col-lg-offset-2">
            <br />
            <asp:Button ID="Submit" runat="server" Height="43px" Text="Submit" Width="147px" 
                OnClick="Submit_Click" CssClass="btn btn-primary"/>
            <asp:Button ID="Cancel" runat="server" Height="43px" Text="Cancel" Width="147px" 
                OnClick="Cancel_Click" CssClass="btn btn-default"/>
        </div>
    </div>
    </fieldset>
</asp:Content>
