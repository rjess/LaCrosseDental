<%@ Page Title="Scheduled Appointments" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewAppointments.aspx.cs" Inherits="LaCrosseDental.ViewAppointments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div>
            <hgroup>
                <h2><%: Page.Title %> </h2>
            </hgroup>
            <div>
                <label>Search All Appointments: </label>
                <input id="SearchText" type="text" runat="server"/>
                <asp:Button ID="SearchButton" runat="server" Text="Search" CssClass="btn btn-primary" 
                    height="35px" Width="100px" OnClick="SearchButton_Click"/>
            </div>
            <asp:ListView ID="appointmentList" runat="server" 
                DataKeyNames="AppointmentID" GroupItemCount="1"
                ItemType="LaCrosseDental.Models.Appointment" SelectMethod="getAppointments">
                <EmptyDataTemplate>
                    <table >
                        <tr>
                            <td>No Current Appointments</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <td/>
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td runat="server">
                        <table>
                            <tr runat="server">
                                <td>
                                    <span>
                                        <b><%#:Item.Type%></b><i>&ensp;on&ensp;</i><%#:Item.Time.ToShortDateString()%><i>&ensp;at&ensp;</i><%#:Item.Time.ToShortTimeString()%></span>
                                    <br />
                                    <span><b>&emsp;| Patient&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&ensp;</b><%#:Item.PatientName%></span>
                                    <br />
                                    <span><b>&emsp;| Doctor&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&ensp;</b><%#:Item.DoctorName%></span>
                                    <br />
                                    <span><b>&emsp;| Hygienist&nbsp;&nbsp;&nbsp;&nbsp;:&ensp;</b><%#:Item.HygienistName%></span>
                                    <br />
                                    <span><b>&emsp;| Confirmed&nbsp;&nbsp;:&ensp;</b><%#:Item.Confirmed%></span>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        </p>
                    </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table class="table table-striped table-hover">
                        <tbody>
                            <tr runat="server">
                                <td>
                                    <table id="groupPlaceholderContainer" runat="server" style="width:100%">
                                        <tr id="groupPlaceholder"></tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr></tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
        </div>
        <div>
            <asp:ListView ID="SearchResults" runat="server" 
                DataKeyNames="AppointmentID" GroupItemCount="1"
                ItemType="LaCrosseDental.Models.Appointment" SelectMethod="searchAppointments"
                visible="false">
                <EmptyDataTemplate>
                    <table >
                        <tr>
                            <td>No Current Appointments</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <td/>
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td runat="server">
                        <table>
                            <tr runat="server">
                                <td>
                                    <span>
                                        <b><%#:Item.Type%></b><i>&ensp;on&ensp;</i><%#:Item.Time.ToShortDateString()%><i>&ensp;at&ensp;</i><%#:Item.Time.ToShortTimeString()%></span>
                                    <br />
                                    <span><b>&emsp;| Patient&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&ensp;</b><%#:Item.PatientName%></span>
                                    <br />
                                    <span><b>&emsp;| Doctor&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&ensp;</b><%#:Item.DoctorName%></span>
                                    <br />
                                    <span><b>&emsp;| Hygienist&nbsp;&nbsp;&nbsp;&nbsp;:&ensp;</b><%#:Item.HygienistName%></span>
                                    <br />
                                    <span><b>&emsp;| Confirmed&nbsp;&nbsp;:&ensp;</b><%#:Item.Confirmed%></span>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        </p>
                    </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table class="table table-striped table-hover">
                        <tbody>
                            <tr runat="server">
                                <td>
                                    <table id="groupPlaceholderContainer" runat="server" style="width:100%">
                                        <tr id="groupPlaceholder"></tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr></tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
        </div>
    </section>
</asp:Content>
