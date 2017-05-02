<!--This  is the request appointment page when on the La Crosse Dental Website-->
<%@ Page Title="Request Appointment" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RequestAppointment.aspx.cs" Inherits="LaCrosseDental.RequestAppointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
    <br />
    <legend>Add Appointment</legend>
    <div class="form-group" runat="server">
      <label for="selectDate" class="col-lg-2 control-label">Select Date</label>
      <div class="col-lg-10">
          <div class="calendarWrapper">
            <asp:Calendar ID="Calendar1" runat="server" Height="250px" Width="400px" BorderColor="Silver"
                BorderStyle="None" BorderWidth="3" ShowGridLines="true" TitleFormat="MonthYear" 
                TitleStyle-BackColor="#993366" BackColor="White" DayStyle-BackColor="White"
                 TitleStyle-ForeColor="White" TitleStyle-Font-Bold="true" Font="glyphicons-halflings-regular"
                 DayHeaderStyle-BackColor="WhiteSmoke" DayHeaderStyle-Font-Bold="true" SelectedDayStyle-BackColor="OrangeRed"
                 SelectedDayStyle-ForeColor="White" WeekendDayStyle-BackColor="Black" NextPrevStyle-ForeColor="White"
                 NextPrevStyle-Font-Bold="true"></asp:Calendar>
          </div>
          <br>
      </div>
    </div>
    <div class="form-group" runat="server">
      <label class="col-lg-2 control-label">Appointment Type</label>
      <div class="col-lg-10">
        <asp:RadioButtonList ID="apptType" runat="server" Height="69px" Width="156px" CssClass="radio">
         <asp:ListItem>Cleaning</asp:ListItem>
         <asp:ListItem>Tooth Extraction</asp:ListItem>
         <asp:ListItem>Cavity Filling</asp:ListItem>
        </asp:RadioButtonList>
        <br>
      </div>
    </div>
    <div class="form-group" runat="server">
      <label for="select" class="col-lg-2 control-label">Time of Day</label>
      <div class="col-lg-10">
        <asp:DropDownList ID="timeOfDay" runat="server" Height="31px" Width="109px" CssClass="form-control">
            <asp:ListItem Value="7">7:00 am</asp:ListItem>
            <asp:ListItem Value="8">8:00 am</asp:ListItem>
            <asp:ListItem Value="9">9:00 am</asp:ListItem>
            <asp:ListItem Value="10">10:00 am</asp:ListItem>
            <asp:ListItem Value="11">11:00 am</asp:ListItem>
            <asp:ListItem Value="13">1:00 pm</asp:ListItem>
            <asp:ListItem Value="14">2:00 pm</asp:ListItem>
            <asp:ListItem Value="15">3:00 pm</asp:ListItem>
            <asp:ListItem Value="16">4:00 pm</asp:ListItem>
            <asp:ListItem Value="17">5:00 pm</asp:ListItem>
        </asp:DropDownList>
        <br>
      </div>
    </div>
    <div class="form-group" runat="server">
      <div class="col-lg-10 col-lg-offset-2">
        <asp:Button runat="server" Text="Cancel" CssClass="btn btn-default"/>
        <asp:Button runat="server" OnClick="addAppointment" Text="Submit" CssClass="btn btn-primary"/>
      </div>
    </div>
  </fieldset>
</asp:Content>
