namespace LaCrosseDental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAppointments : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        AppointmentID = c.String(nullable: false, maxLength: 128),
                        Time = c.DateTime(nullable: false),
                        Type = c.String(),
                        PatientID = c.String(),
                        DoctorID = c.String(),
                        HygienistID = c.String(),
                        Confirmed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AppointmentID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Appointments");
        }
    }
}
