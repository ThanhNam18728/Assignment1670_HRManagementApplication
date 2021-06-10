namespace HRManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemaneDbCourseUsers : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CoursesUsers", newName: "CoursesTrainers");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.CoursesTrainers", newName: "CoursesUsers");
        }
    }
}
