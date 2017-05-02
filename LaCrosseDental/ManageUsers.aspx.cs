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
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                con.Open();

                SqlCommand cmd1 = new SqlCommand("SELECT Id, Name FROM AspNetUsers", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                sda.Fill(dt);
                con.Close();
            }

            if (!IsPostBack)
            {
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
                userSelect.Visible = true;
                Name.Visible = true;
                Username.Visible = true;
                Email.Visible = true;
                UserType.Visible = true;
                Password.Visible = false;
            }
            if (selection.Equals("Create User"))
            {
                userSelect.Visible = false;
                Name.Visible = true;
                Name.Text = "";
                Username.Visible = true;
                Username.Text = "";
                Email.Visible = true;
                Email.Text = "";
                UserType.Visible = true;
                UserType.Text = "";
                Password.Visible = true;
                Password.Text = "";
            }
            if (selection.Equals("Deactivate User"))
            {
                userSelect.Visible = true;
                Name.Visible = false;
                Username.Visible = false;
                Email.Visible = false;
                UserType.Visible = false;
                Password.Visible = false;
            }
        }
        
        protected void UpdateFields(object sender, EventArgs e)
        {
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
            string selection = RadioList.SelectedValue;
            if(selection.Equals("Edit User"))
            {
                userSelect.Visible = true;
                Name.Visible = true;
                Username.Visible = true;
                Email.Visible = true;
                UserType.Visible = true;
                Password.Visible = false;
            }
            if(selection.Equals("Create User"))
            {
                userSelect.Visible = false;
                Name.Visible = true;
                Username.Visible = true;
                Email.Visible = true;
                UserType.Visible = true;
                Password.Visible = true;
            }
            if(selection.Equals("Deactivate User"))
            {
                userSelect.Visible = true;
                Name.Visible = false;
                Username.Visible = false;
                Email.Visible = false;
                UserType.Visible = false;
                Password.Visible = false;
            }
        }

        protected void SubmitEdit(object sender, EventArgs e)
        {
            // Grab Radio selection value and execute respective submit
            string selection = RadioList.SelectedValue;
            // Edit User
            if (selection.Equals("Edit User"))
            {
                // Database and User Manager info and variables
                ApplicationDbContext db = new ApplicationDbContext();
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
                // assign new user to a Role
                string type = UserType.Text;
                string role = "";
                // convert type to corresponding role
                if (type.Equals("Patient")) role = "patient";
                else if (type.Equals("Doctor") || type.Equals("Hygienist")) role = "user";

                // add user to role
                RoleActions r = new RoleActions();
                r.AddUserAndRole(Email.Text, Password.Text, role, Name.Text, UserType.Text);
            }
            if (selection.Equals("Deactivate User"))
            {
                // Database and User Manager info and variables
                ApplicationDbContext db = new ApplicationDbContext();
                var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                String userid = userSelect.SelectedValue;
                var user = userMgr.FindById(userid);

                // lock out user
                user.LockoutEnabled = true;
            }

            // redirect to return url
            IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
        }
    }
}
