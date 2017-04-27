using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LaCrosseDental.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace LaCrosseDental.Logic
{
    internal class RoleActions
    {
        internal void AddUserAndRole(String email, String password, String role, String name, String type)
        {
            // Access the application context and create result variables.
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
            if (!roleMgr.RoleExists(role))
            {
                IdRoleResult = roleMgr.Create(new IdentityRole { Name = role });
            }

            // Create a UserManager object based on the UserStore object and the ApplicationDbContext  
            // object. Note that you can create new objects and use them as parameters in
            // a single line of code, rather than using multiple lines of code, as you did
            // for the RoleManager object.
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var appUser = new ApplicationUser
            {
                UserName = email,
                Email = email,
                Name = name,
                Type = type
            };
            IdUserResult = userMgr.Create(appUser, password);

            context.SaveChanges();
            if (!IdUserResult.Succeeded) return;
            // If the new "admin" user was successfully created, 
            // add the "admin" user to the "admin" role. 
            if (!userMgr.IsInRole(userMgr.FindByEmail(email).Id, role))
            {
                IdUserResult = userMgr.AddToRole(userMgr.FindByEmail(email).Id, role);
            }
        }
        internal void AddRole( ApplicationUser user, String role )
        {
            Models.ApplicationDbContext context = new ApplicationDbContext();
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            
            if (!userMgr.IsInRole(user.Id, role))
            {
                userMgr.AddToRole(user.Id, role);
            }
        }
    }
}