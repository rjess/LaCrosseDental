using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LaCrosseDental.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LaCrosseDental
{
    public partial class ManageSchedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /* Bind User's appointments to the ListBox */
                ApplicationDbContext context = new ApplicationDbContext();
                IQueryable<Appointment> appts = context.Appointments;

                // get user ID
                String id = User.Identity.GetUserId();

                // get the user's appts
                appts = appts.Where(a => a.DoctorID == id || a.HygienistID == id);

                // create new anonymous type for the listbox for each appointment in appts
                var datasource = from a in appts
                                 select new
                                 {
                                     aID = a.AppointmentID,
                                     ApptName = a.PatientName + " @ " + a.Time
                                 };

                // Bind data
                Appointments.DataSource = datasource.ToList();
                Appointments.DataTextField = "ApptName";
                Appointments.DataValueField = "aID";
                Appointments.DataBind();
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            // cancel the appointment then notify admin or user
            ApplicationDbContext context = new ApplicationDbContext();
            var apptId = Appointments.SelectedValue;

            // find appointment
            var appt = context.Appointments.Where(a => a.AppointmentID == apptId);

            // remove the appointment, save, then redirect
            context.Appointments.Remove(appt.First());
            context.SaveChanges();

            IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
        }
        
    }
}