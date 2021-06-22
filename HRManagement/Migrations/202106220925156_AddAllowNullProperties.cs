namespace HRManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAllowNullProperties : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Trainees", "ProgrammingLanguage", c => c.String());
            AlterColumn("dbo.Trainees", "Experience", c => c.String());
            AlterColumn("dbo.Trainees", "Department", c => c.String());
            AlterColumn("dbo.Trainees", "Location", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Trainees", "Location", c => c.String(nullable: false));
            AlterColumn("dbo.Trainees", "Department", c => c.String(nullable: false));
            AlterColumn("dbo.Trainees", "Experience", c => c.String(nullable: false));
            AlterColumn("dbo.Trainees", "ProgrammingLanguage", c => c.String(nullable: false));
        }
    }
}
