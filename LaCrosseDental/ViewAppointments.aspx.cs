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
//This is for viewing appointment in the La Crosse Dental web application
namespace LaCrosseDental
{
    public partial class ViewAppointments : System.Web.UI.Page
    {
        bool search;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                search = true;
                SearchResults.Visible = true;
                appointmentList.Visible = false;
            } else
            {
                search = false;
                SearchResults.Visible = false;
                appointmentList.Visible = true;
            }
        }
        
        /*
         * getAppointments method to populate the listview
         */
        public IQueryable<Appointment> getAppointments()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            // find the user
            String id = User.Identity.GetUserId();
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            // get all appointments
            IQueryable<Appointment> appts = db.Appointments;

            // refine appointments list according to user
            if (userMgr.IsInRole(id, "user"))
            {
                String name = userMgr.FindById(id).Name;
                appts = appts.Where(a => a.DoctorName == name || a.HygienistName == name);
            }
            else if (userMgr.IsInRole(id, "patient"))
            {
                appts = appts.Where(a => a.PatientID == id);
            }
            // else if it's the admin, it keeps appts as all appointments

            return appts;
            
        }

        public IQueryable<Appointment> searchAppointments()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            // find the user
            String name = SearchText.Value;

            // get all appointments
            IQueryable<Appointment> appts = db.Appointments;

            if (!name.Equals(""))
            {
                // refine appointments list according to user
                appts = appts.Where(a => a.DoctorName == name || a.HygienistName == name || a.PatientName == name);
            }

            return appts;
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            search = true;
            appointmentList.Dispose();
        }
    }
}
