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
//This is for managing users for the La Crosse Dental application
namespace LaCrosseDental
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // data table for getting users
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                con.Open();

                // SQL command to fill dt with all users
                SqlCommand cmd1 = new SqlCommand("SELECT Id, Name FROM AspNetUsers", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                sda.Fill(dt);
                con.Close();
            }

            if (!IsPostBack)
            {
                // populate userSelect field
                userSelect.DataSource = dt;
                userSelect.DataTextField = "Name";
                userSelect.DataValueField = "Id";
                userSelect.DataBind();

                RadioList.SelectedIndex = 0;
            }

            /*
             * Show items according to Radio selection value
             */
            string selection = RadioList.SelectedValue;
            if (selection.Equals("Edit User"))
            {
                userSelectGroup.Visible = true;
                NameGroup.Visible = true;
                UsernameGroup.Visible = true;
                EmailGroup.Visible = true;
                UserTypeGroup.Visible = true;
                PasswordGroup.Visible = false;
                UpdateFields(null, null);
            }
            if (selection.Equals("Create User"))
            {
                userSelectGroup.Visible = false;
                NameGroup.Visible = true;
                Name.Text = "";
                UsernameGroup.Visible = true;
                Username.Text = "";
                EmailGroup.Visible = true;
                Email.Text = "";
                UserTypeGroup.Visible = true;
                UserType.Text = "";
                PasswordGroup.Visible = true;
                Password.Text = "";
            }
            if (selection.Equals("Deactivate User"))
            {
                userSelectGroup.Visible = true;
                NameGroup.Visible = false;
                UsernameGroup.Visible = false;
                EmailGroup.Visible = false;
                UserTypeGroup.Visible = false;
                PasswordGroup.Visible = false;
            }
        }
        
        protected void UpdateFields(object sender, EventArgs e)
        {
            /*Update the data in each field after changing user selection*/
            ApplicationDbContext db = new ApplicationDbContext();
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            String userid = userSelect.SelectedValue;
            var user = userMgr.FindById(userid);

            Name.Text = user.Name;
            Username.Text = user.UserName;
            Email.Text = user.Email;
            UserType.Text = user.Type;
        }

        protected void RadioSelection(object sender, EventArgs e)
        {
            /*Change which fields are visible according to Radio selection*/
            string selection = RadioList.SelectedValue;
            if(selection.Equals("Edit User"))
            {
                userSelect.Visible = true;
                NameGroup.Visible = true;
                UsernameGroup.Visible = true;
                EmailGroup.Visible = true;
                UserTypeGroup.Visible = true;
                PasswordGroup.Visible = false;
            }
            if(selection.Equals("Create User"))
            {
                userSelect.Visible = false;
                NameGroup.Visible = true;
                UsernameGroup.Visible = true;
                EmailGroup.Visible = true;
                UserTypeGroup.Visible = true;
                PasswordGroup.Visible = true;
            }
            if(selection.Equals("Deactivate User"))
            {
                userSelect.Visible = true;
                NameGroup.Visible = false;
                UsernameGroup.Visible = false;
                EmailGroup.Visible = false;
                UserTypeGroup.Visible = false;
                PasswordGroup.Visible = false;
            }
        }

        protected void CreateUser()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();

            // create user
            var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text, Name = Name.Text, Type = UserType.Text };
            IdentityResult result = manager.Create(user, Password.Text);

            db.SaveChanges();

            // get role
            string role = "";
            if (UserType.Text.Equals("Patient")) role = "patient";
            else if (UserType.Text.Equals("Doctor") || UserType.Text.Equals("Hygienist")) role = "user";

            if (result.Succeeded)
            {
                RoleActions r = new RoleActions();
                r.AddRole(user, role);

                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }

        protected void SubmitEdit(object sender, EventArgs e)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            // Grab Radio selection value and execute respective submit
            string selection = RadioList.SelectedValue;
            // Edit User
            if (selection.Equals("Edit User"))
            {
                // Database and User Manager info and variables
                var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                String userid = userSelect.SelectedValue;
                var user = userMgr.FindById(userid);

                // Update user info
                user.Name = Name.Text;
                user.Email = Email.Text;
                user.UserName = Username.Text;
                user.Type = UserType.Text;
                
                db.SaveChanges();
            }
            // Create User
            if (selection.Equals("Create User"))
            {
                CreateUser();
            }
            if (selection.Equals("Deactivate User"))
            {
                // Database and User Manager info and variables
                var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                String userid = userSelect.SelectedValue;
                var user = userMgr.FindById(userid);

                // remove appointments the user belongs to
                IQueryable<Appointment> appts = db.Appointments;
                appts = appts.Where(a => a.DoctorID == userid || a.HygienistID == userid || a.PatientID == userid);
                foreach(Appointment a in appts)
                {
                    db.Appointments.Remove(a);
                }

                // delete user
                db.Users.Remove(user);
                db.SaveChanges();

                // add the new inactive user
                user.Type = "Inactive";
                db.Users.Add(user);

                db.SaveChanges();
            }

            // redirect to return url
            IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
        }
    }
}
