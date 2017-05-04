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
    public partial class ViewAppointments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
                appts = appts.Where(a => a.DoctorID == name || a.HygienistID == name);
            }
            else if (userMgr.IsInRole(id, "patient"))
            {
                appts = appts.Where(a => a.PatientID == id);
            }
            // else if it's the admin, it keeps appts as all appointments
            
            return appts;
        }
    }
}