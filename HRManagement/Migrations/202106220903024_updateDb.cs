namespace HRManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDb : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trainers", "Type", c => c.String());
            AlterColumn("dbo.Trainers", "WorkingPlace", c => c.String());
            AlterColumn("dbo.Trainers", "EmailAddress", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trainers", "EmailAddress", c => c.String(nullable: false));
            AlterColumn("dbo.Trainers", "WorkingPlace", c => c.String(nullable: false));
            AlterColumn("dbo.Trainers", "Type", c => c.String(nullable: false));
        }
    }
}
