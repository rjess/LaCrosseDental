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
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        public IQueryable<Appointment> getAppointments()
        {
            ApplicationDbContext db = new ApplicationDbContext();

            String id = User.Identity.GetUserId();
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            IQueryable<Appointment> appts = db.Appointments;

            if (userMgr.IsInRole(id, "user"))
            {
                String name = userMgr.FindById(id).Name;
                appts = appts.Where(a => a.DoctorID == name || a.HygienistID == name);
            }
            else if (userMgr.IsInRole(id, "patient"))
            {
                appts = appts.Where(a => a.PatientID == id);
            }
            
            return appts;
        }
    }
}
