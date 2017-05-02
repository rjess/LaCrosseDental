using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LaCrosseDental.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
//This is for manage appointment's for the La Crosse Dental Web Application
namespace LaCrosseDental
{
    public partial class ManageAppointments : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            String date = ListBox1.SelectedValue;
            DateTime dt = DateTime.Parse(date);

            int docidx = SelectDoc.SelectedIndex;
            int hygidx = SelectHyg.SelectedIndex;

            String doc = "Dan Johnson";
            String hyg = "Mary Riley";

            IQueryable<Appointment> appts = context.Appointments;
            appts = appts.Where(a => a.Time == dt);
            Appointment ap;
            ap = appts.First();

            ap.DoctorID = doc;
            ap.HygienistID = hyg;
            ap.Confirmed = true;

            context.SaveChanges();

            IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
        }
    }
}
