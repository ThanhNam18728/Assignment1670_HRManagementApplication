namespace HRManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteStaffModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Staffs", "StaffId", "dbo.AspNetUsers");
            DropIndex("dbo.Staffs", new[] { "StaffId" });
            DropTable("dbo.Staffs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        StaffId = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.StaffId);
            
            CreateIndex("dbo.Staffs", "StaffId");
            AddForeignKey("dbo.Staffs", "StaffId", "dbo.AspNetUsers", "Id");
        }
    }
}
