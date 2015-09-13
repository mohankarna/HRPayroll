namespace HRPayroll.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Muster1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 200),
                        EmployeeId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .ForeignKey("dbo.Roles", t => t.RoleId)
                .Index(t => t.EmployeeId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Users", "EmployeeId", "dbo.Employee");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Users", new[] { "EmployeeId" });
            DropTable("dbo.Users");
            DropTable("dbo.Roles");
        }
    }
}
