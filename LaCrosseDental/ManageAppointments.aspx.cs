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
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using LaCrosseDental.Logic;

namespace LaCrosseDental
{
    public partial class ManageAppointments : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            /* data table for doctors*/
            DataTable docs = new DataTable();
            /* data table for hygienists*/
            DataTable hygs = new DataTable();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                con.Open();

                // SQL commands to retrieve doctors and hygienists
                SqlCommand cmd1 = new SqlCommand("SELECT Id, Name, Type FROM AspNetUsers as U WHERE U.Type = 'Doctor'", con);
                SqlCommand cmd2 = new SqlCommand("Select Id, Name, Type FROM AspNetUsers as U WHERE U.Type = 'Hygienist'", con);
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
                SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);

                // Fill the docs and hygs datatables with the sql results
                sda1.Fill(docs);
                sda2.Fill(hygs);

                con.Close();
            }

            if (!IsPostBack)
            {
                /*###### Bind data to select fields ########*/
                docSelect.DataSource = docs;
                docSelect.DataTextField = "Name";
                docSelect.DataValueField = "Id";
                docSelect.DataBind();

                hygSelect.DataSource = hygs;
                hygSelect.DataTextField = "Name";
                hygSelect.DataValueField = "Id";
                hygSelect.DataBind();

                /* Bind unconfirmed appointments to the ListBox */
                ApplicationDbContext context = new ApplicationDbContext();
                IQueryable<Appointment> appts = context.Appointments;
                // get the unconfirmed appts
                appts = appts.Where(a => a.Confirmed == false);

                // create new anonymous type for the listbox for each unconfirmed appt
                var datasource = from a in appts
                                 select new
                                 {
                                     ID = a.AppointmentID,
                                     ApptName = a.PatientName + " @ " + a.Time
                                 };

                // Bind data
                ListBox1.DataSource = datasource.ToList();
                ListBox1.DataTextField = "ApptName";
                ListBox1.DataValueField = "ID";
                ListBox1.DataBind();
            }
        }

        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void CheckDoc(object sender, EventArgs e)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            // Get doctor
            String docid = docSelect.SelectedValue;
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var doc = userMgr.FindById(docid);

            // get selected Appointment
            String apptId = ListBox1.SelectedValue;
            IQueryable<Appointment> appts = context.Appointments;
            appts = appts.Where(a => a.AppointmentID == apptId);
            Appointment ap;

            try
            {
                ap = appts.First();
            }
            catch (Exception)
            {
                return;
            }

            // get Appointment date time
            DateTime apptDT = ap.Time;

            // query appointments for all of the Doc's existing appointments
            appts = context.Appointments;
            appts = appts.Where(a => a.DoctorID == docid);

            // check if the Doc already has an appointment at that time
            bool available = true;
            var apptList = appts.ToList();
            foreach (Appointment a in apptList)
            {
                if( a.Time.Equals(apptDT))
                {
                    available = false;
                }
            }

            if(!available)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), 
                    "AlertBox", "alert('This Doctor is already scheduled at that time!');", true);
            }

        }
        protected void CheckHyg(object sender, EventArgs e)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            // Get hygienist
            String hygid = hygSelect.SelectedValue;
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var hyg = userMgr.FindById(hygid);

            // get selected Appointment
            String apptId = ListBox1.SelectedValue;
            IQueryable<Appointment> appts = context.Appointments;
            appts = appts.Where(a => a.AppointmentID == apptId);
            Appointment ap;
            try
            {
                ap = appts.First();
            }
            catch(Exception)
            {
                return;
            }
            // get Appointment date time
            DateTime apptDT = ap.Time;

            // query appointments for all of the Hyg's existing appointments
            appts = context.Appointments;
            appts = appts.Where(a => a.HygienistID == hygid);

            // check if the Hyg already has an appointment at that time
            bool available = true;
            var apptList = appts.ToList();
            foreach (Appointment a in apptList)
            {
                if (a.Time.Equals(apptDT))
                {
                    available = false;
                }
            }

            if (!available)
            {
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(),
                    "AlertBox", "alert('This Hygienist is already scheduled at that time!');", true);
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            ApplicationDbContext context = new ApplicationDbContext();

            // get the selected appointment ID
            String apptId = ListBox1.SelectedValue;
            
            // get selected doc and hyg IDs
            String docid = docSelect.SelectedValue;
            String hygid = hygSelect.SelectedValue;

            // get list of appointments and query for the specific appointment
            IQueryable<Appointment> appts = context.Appointments;
            appts = appts.Where(a => a.AppointmentID == apptId);
            Appointment ap;
            ap = appts.First();

            // use UserManager to find the selected Doctor and Hygienist
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var doc = userMgr.FindById(docid);
            var hyg = userMgr.FindById(hygid);

            // update Appointment's doctor/hyg and confirm it
            ap.DoctorID = doc.Id;
            ap.HygienistID = hyg.Id;
            ap.DoctorName = doc.Name;
            ap.HygienistName = hyg.Name;
            ap.Confirmed = true;

            // save and redirect to previous url
            context.SaveChanges();
            IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
        }
    }
}