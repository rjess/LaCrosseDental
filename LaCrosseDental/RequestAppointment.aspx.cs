using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using LaCrosseDental.Models;

namespace LaCrosseDental
{
    public partial class RequestAppointment : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        
        /**
         * addAppointment : add the appointment to the database
         */
        protected void addAppointment(object sender, EventArgs e)
        {
            DateTime dt = Calendar1.SelectedDate;
            int hour = Int32.Parse(timeOfDay.SelectedValue);

            // set hours field of datetime
            dt = dt.AddHours(hour);

            // get db context and instantiate new Appointment
            ApplicationDbContext db = new ApplicationDbContext();
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = userMgr.FindById(User.Identity.GetUserId());

            Appointment newAppt = new Appointment()
            {
                AppointmentID = "" + dt.Month + dt.Day + hour,
                Time = dt,
                PatientID = user.Id,
                PatientName = user.Name,
                Type = apptType.SelectedValue,
                DoctorID = "",
                HygienistID = "",
                Confirmed = false
            };

            db.Appointments.Add(newAppt);
            db.SaveChanges();
            
            IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
        }

    }
}
