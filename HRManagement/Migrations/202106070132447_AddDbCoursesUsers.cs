namespace HRManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDbCoursesUsers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CoursesUsers",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.CourseId })
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CoursesUsers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CoursesUsers", "CourseId", "dbo.Courses");
            DropIndex("dbo.CoursesUsers", new[] { "CourseId" });
            DropIndex("dbo.CoursesUsers", new[] { "UserId" });
            DropTable("dbo.CoursesUsers");
        }
    }
}
