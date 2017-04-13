namespace LaCrosseDental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExtraAttributes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "PatientName", c => c.String());
            AddColumn("dbo.Appointments", "DoctorName", c => c.String());
            AddColumn("dbo.Appointments", "HygienistName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Type");
            DropColumn("dbo.Appointments", "HygienistName");
            DropColumn("dbo.Appointments", "DoctorName");
            DropColumn("dbo.Appointments", "PatientName");
        }
    }
}
