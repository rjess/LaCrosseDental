<!--This  is the manage appointment page when on the La Crosse Dental Website-->
<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageAppointments.aspx.cs" Inherits="LaCrosseDental.ManageAppointments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
    <legend>Approve Appointments</legend>
    <div class="form-group">
        <label for="list" class="col-lg-2 control-label">Unconfirmed Appointments</label>
        <div class="col-lg-10">
        <asp:ListBox ID="ListBox1" runat="server" DataSourceID="SqlDataSource1" DataTextField="Time" DataValueField="Time" Height="160px" 
                  OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" Width="450px" SelectionMode="Single"
                  BorderStyle="Solid" Font-Bold="True" Font-Size="14pt" CssClass=""></asp:ListBox>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [Appointments] WHERE ([Confirmed] = @Confirmed)">
            <SelectParameters>
                <asp:Parameter DefaultValue="false" Name="Confirmed" Type="Boolean" />
          </SelectParameters>
        </asp:SqlDataSource>
        </div>
    </div>
        <br />
    <div class="form-group">
        <label for="select" class="col-lg-2 control-label">Choose Doctor</label>
        <div class="col-lg-10">
            <select class="form-control" ID="SelectDoc" name="S1" runat="server">
              <option>Dan Johnson</option>
            </select>
        </div>
    </div>
    <div class="form-group">
        <label for="select" class="col-lg-2 control-label">Choose Hygienist</label>
        <div class="col-lg-10">
            <select class="form-control" ID="SelectHyg" name="S2" runat="server">
              <option>Mary Riley</option>
            </select>
        </div>
    </div>
        <br />
    <div class="form-group">
        <div class="col-lg-10 col-lg-offset-2">
        <br />
        <asp:Button ID="Submit" runat="server" Height="43px" Text="Submit" Width="147px" 
            OnClick="Submit_Click" CssClass="btn btn-primary"/>
        </div>
    </div>
    </fieldset>
</asp:Content>
