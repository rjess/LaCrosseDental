namespace LaCrosseDental.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using LaCrosseDental.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<LaCrosseDental.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "LaCrosseDental.Models.ApplicationDbContext";
        }

        protected override void Seed(LaCrosseDental.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            DateTime dt = new DateTime(2017, 1, 1, 10, 0, 0);
            ApplicationDbContext db2 = new ApplicationDbContext();

            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db2));
            String patient = userMgr.FindByEmail("ryanjessen@laxdental.com").Id;

            Appointment a = new Models.Appointment
            {
                AppointmentID = "" + dt.Month + dt.Day + dt.Hour,
                Time = dt,
                Confirmed = true,
                DoctorID = "Dan Johnson",
                HygienistID = "Mary Riley",
                PatientID = patient,
                Type = "Tooth Extraction"
            };

            context.Appointments.Add(a);

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}

