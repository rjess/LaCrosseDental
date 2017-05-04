using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using LaCrosseDental.Logic;
using LaCrosseDental.Models;
//This is for the global class for the La Crosse Dental Application
namespace LaCrosseDental
{
    public class Global : HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            // add admin user
            Models.ApplicationDbContext context = new ApplicationDbContext();
            IdentityResult IdRoleResult;
            IdentityResult IdUserResult;

            // Create a RoleStore object by using the ApplicationDbContext object. 
            // The RoleStore is only allowed to contain IdentityRole objects.
            var roleStore = new RoleStore<IdentityRole>(context);

            // Create a RoleManager object that is only allowed to contain IdentityRole objects.
            // When creating the RoleManager object, you pass in (as a parameter) a new RoleStore object. 
            var roleMgr = new RoleManager<IdentityRole>(roleStore);

            // Then, create the role if it doesn't already exist.
            if (!roleMgr.RoleExists("admin"))
            {
                IdRoleResult = roleMgr.Create(new IdentityRole { Name = "admin" });
            }

            // Create a UserManager object based on the UserStore object and the ApplicationDbContext  
            // object. Note that you can create new objects and use them as parameters in
            // a single line of code, rather than using multiple lines of code, as you did
            // for the RoleManager object.
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var appUser = new ApplicationUser
            {
                UserName = "admin@laxdental.com",
                Email = "admin@laxdental.com",
                Type = "Admin",
                Name = "Admin"
            };
            IdUserResult = userMgr.Create(appUser, "Pa$$word1");

            // If the new "admin" user was successfully created, 
            // add the "admin" user to the "admin" role. 
            if (!userMgr.IsInRole(userMgr.FindByEmail(appUser.Email).Id, "admin"))
            {
                IdUserResult = userMgr.AddToRole(userMgr.FindByEmail(appUser.Email).Id, "admin");
            }
            // Create the roles and users.
            RoleActions roleActions = new RoleActions();
            roleActions.AddUserAndRole("admin@laxdental.com", "Pa$$word1", "admin", "Admin", "Admin");
            roleActions.AddUserAndRole("maryriley@laxdental.com", "Pa$$word1", "user", "Mary Riley", "Hygienist");
            roleActions.AddUserAndRole("danjohnson@laxdental.com", "Pa$$word1", "user", "Dan Johnson", "Doctor");
            roleActions.AddUserAndRole("annianderson@laxdental.com", "Pa$$word1", "patient", "Anni Anderson", "Patient");
            roleActions.AddUserAndRole("keywayne@laxdental.com", "Pa$$word1", "user", "Key Wayne", "Hygienist");
            roleActions.AddUserAndRole("timflood@laxdental.com", "Pa$$word1", "user", "Tim Flood", "Doctor");
            roleActions.AddUserAndRole("jessen.ryan@uwlax.edu", "Pa$$word1", "patient", "Ryan Jessen", "Patient");
            roleActions.AddUserAndRole("janedoe@laxdental.com", "Pa$$word1", "patient", "Jane Doe", "Patient");
        }
    }
}
