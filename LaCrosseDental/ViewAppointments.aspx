<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewAppointments.aspx.cs" Inherits="LaCrosseDental.ViewAppointments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div>
            <hgroup>
                <h2><%: Page.Title %></h2>
            </hgroup>
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
                                        <b>Patient: </b><%#:Item.PatientName%>
                                    </span>
                                    <span>
                                        <b>Appointment On </b><%#:Item.Time.ToString()%>
                                    </span>
                                    <br />
                                    <span>
                                        <b>Type         : </b><%#:Item.Type%>
                                    </span>
                                    <br />
                                    <span>
                                        <b>Doctor       : </b><%#:Item.DoctorID%>
                                    </span>
                                    <br />
                                    <span>
                                        <b>Hygienist    : </b><%#:Item.HygienistID%>
                                    </span>
                                    <br />
                                    <span>
                                        <b>Confirmed    : </b><%#:Item.Confirmed%>
                                    </span>
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
