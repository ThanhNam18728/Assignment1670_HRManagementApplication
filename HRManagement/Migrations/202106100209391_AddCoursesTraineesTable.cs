namespace HRManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCoursesTraineesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CoursesTrainees",
                c => new
                    {
                        TraineeId = c.String(nullable: false, maxLength: 128),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TraineeId, t.CourseId })
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.TraineeId, cascadeDelete: true)
                .Index(t => t.TraineeId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CoursesTrainees", "TraineeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CoursesTrainees", "CourseId", "dbo.Courses");
            DropIndex("dbo.CoursesTrainees", new[] { "CourseId" });
            DropIndex("dbo.CoursesTrainees", new[] { "TraineeId" });
            DropTable("dbo.CoursesTrainees");
        }
    }
}
