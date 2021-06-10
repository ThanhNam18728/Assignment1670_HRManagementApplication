namespace HRManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeFK : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CoursesUsers", name: "UserId", newName: "TrainerId");
            RenameIndex(table: "dbo.CoursesUsers", name: "IX_UserId", newName: "IX_TrainerId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.CoursesUsers", name: "IX_TrainerId", newName: "IX_UserId");
            RenameColumn(table: "dbo.CoursesUsers", name: "TrainerId", newName: "UserId");
        }
    }
}
