using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LaCrosseDental.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
//This is for the default page for the La Crosse Dental Application 
namespace LaCrosseDental
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.IsInRole("admin"))
            {
                ad1.Visible = true;
                ad2.Visible = true;
                ad3.Visible = true;
            }
            else if (HttpContext.Current.User.IsInRole("user"))
            {
                u1.Visible = true;
                u2.Visible = true;
                u3.Visible = true;
            }
            else if (HttpContext.Current.User.IsInRole("patient"))
            {
                p1.Visible = true;
                p2.Visible = true;
                p3.Visible = true;
            }
            else
            {
                logB.Visible = true;
                regB.Visible = true;
            }
        }

    }
}
