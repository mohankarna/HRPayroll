namespace HRPayroll.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Muster : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdvancePayment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        SalaryAdvance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherAdvance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Purpose = c.String(),
                        PaymentMode = c.String(),
                        Bank = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(maxLength: 100, unicode: false),
                        TitleId = c.Int(nullable: false),
                        GenderId = c.Int(nullable: false),
                        DesignationId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        BranchId = c.Int(nullable: false),
                        MaritalStatusId = c.Int(nullable: false),
                        EmailId = c.String(nullable: false),
                        MobileNo = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branch", t => t.BranchId)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .ForeignKey("dbo.Designation", t => t.DesignationId)
                .ForeignKey("dbo.Gender", t => t.GenderId)
                .ForeignKey("dbo.MaritalStatus", t => t.MaritalStatusId)
                .ForeignKey("dbo.Title", t => t.TitleId)
                .Index(t => t.TitleId)
                .Index(t => t.GenderId)
                .Index(t => t.DesignationId)
                .Index(t => t.DepartmentId)
                .Index(t => t.BranchId)
                .Index(t => t.MaritalStatusId);
            
            CreateTable(
                "dbo.Branch",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BranchName = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false, maxLength: 100),
                        DepartmnentChief = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Designation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DesignationName = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Gender",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenderName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MaritalStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Title",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TitleName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employee1",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Designation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ethenic",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EthenicGroup = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HrGlobalSetup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WorkingHrsPerDay = c.Int(nullable: false),
                        OtRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LeaveReport",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Branch = c.String(),
                        From = c.DateTime(nullable: false),
                        To = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LeaveRequest",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LeaveTypeId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        LeaveFrom = c.DateTime(nullable: false),
                        LeaveTo = c.DateTime(nullable: false),
                        TotalDays = c.Int(nullable: false),
                        Reason = c.String(),
                        IsHalfDay = c.Boolean(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .ForeignKey("dbo.LeaveType", t => t.LeaveTypeId)
                .Index(t => t.LeaveTypeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.LeaveType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LeaveName = c.String(),
                        LeaveDescription = c.String(),
                        AllowedPerYear = c.Int(nullable: false),
                        ServiceTypeId = c.Int(nullable: false),
                        EthenicId = c.Int(nullable: false),
                        MaritalStatusId = c.Int(nullable: false),
                        GenderId = c.Int(nullable: false),
                        AllowHalfDay = c.Boolean(nullable: false),
                        IsPayable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ethenic", t => t.EthenicId)
                .ForeignKey("dbo.Gender", t => t.GenderId)
                .ForeignKey("dbo.MaritalStatus", t => t.MaritalStatusId)
                .ForeignKey("dbo.ServiceType", t => t.ServiceTypeId)
                .Index(t => t.ServiceTypeId)
                .Index(t => t.EthenicId)
                .Index(t => t.MaritalStatusId)
                .Index(t => t.GenderId);
            
            CreateTable(
                "dbo.ServiceType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ServiceName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PayPlanSetup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        BasicSalary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreviousGrade = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrentGrade = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SpecialAllow = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DearnessAllow = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtherAllow = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CIT = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Insurance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employee", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Qualification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AcademicQualification = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TaxSetup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VARCHAR = c.String(nullable: false, maxLength: 50),
                        From = c.DateTime(nullable: false),
                        To = c.DateTime(nullable: false),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaritalStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MaritalStatus", t => t.MaritalStatusId)
                .Index(t => t.MaritalStatusId);
            
            CreateTable(
                "dbo.WorkingDaysEntry",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BranchId = c.Int(nullable: false),
                        Year = c.DateTime(nullable: false),
                        Month = c.String(),
                        TotalDaysInMonth = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Branch", t => t.BranchId)
                .Index(t => t.BranchId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkingDaysEntry", "BranchId", "dbo.Branch");
            DropForeignKey("dbo.TaxSetup", "MaritalStatusId", "dbo.MaritalStatus");
            DropForeignKey("dbo.PayPlanSetup", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.LeaveRequest", "LeaveTypeId", "dbo.LeaveType");
            DropForeignKey("dbo.LeaveType", "ServiceTypeId", "dbo.ServiceType");
            DropForeignKey("dbo.LeaveType", "MaritalStatusId", "dbo.MaritalStatus");
            DropForeignKey("dbo.LeaveType", "GenderId", "dbo.Gender");
            DropForeignKey("dbo.LeaveType", "EthenicId", "dbo.Ethenic");
            DropForeignKey("dbo.LeaveRequest", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.AdvancePayment", "EmployeeId", "dbo.Employee");
            DropForeignKey("dbo.Employee", "TitleId", "dbo.Title");
            DropForeignKey("dbo.Employee", "MaritalStatusId", "dbo.MaritalStatus");
            DropForeignKey("dbo.Employee", "GenderId", "dbo.Gender");
            DropForeignKey("dbo.Employee", "DesignationId", "dbo.Designation");
            DropForeignKey("dbo.Employee", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Employee", "BranchId", "dbo.Branch");
            DropIndex("dbo.WorkingDaysEntry", new[] { "BranchId" });
            DropIndex("dbo.TaxSetup", new[] { "MaritalStatusId" });
            DropIndex("dbo.PayPlanSetup", new[] { "EmployeeId" });
            DropIndex("dbo.LeaveType", new[] { "GenderId" });
            DropIndex("dbo.LeaveType", new[] { "MaritalStatusId" });
            DropIndex("dbo.LeaveType", new[] { "EthenicId" });
            DropIndex("dbo.LeaveType", new[] { "ServiceTypeId" });
            DropIndex("dbo.LeaveRequest", new[] { "EmployeeId" });
            DropIndex("dbo.LeaveRequest", new[] { "LeaveTypeId" });
            DropIndex("dbo.Employee", new[] { "MaritalStatusId" });
            DropIndex("dbo.Employee", new[] { "BranchId" });
            DropIndex("dbo.Employee", new[] { "DepartmentId" });
            DropIndex("dbo.Employee", new[] { "DesignationId" });
            DropIndex("dbo.Employee", new[] { "GenderId" });
            DropIndex("dbo.Employee", new[] { "TitleId" });
            DropIndex("dbo.AdvancePayment", new[] { "EmployeeId" });
            DropTable("dbo.WorkingDaysEntry");
            DropTable("dbo.TaxSetup");
            DropTable("dbo.Student");
            DropTable("dbo.Qualification");
            DropTable("dbo.PayPlanSetup");
            DropTable("dbo.ServiceType");
            DropTable("dbo.LeaveType");
            DropTable("dbo.LeaveRequest");
            DropTable("dbo.LeaveReport");
            DropTable("dbo.HrGlobalSetup");
            DropTable("dbo.Ethenic");
            DropTable("dbo.Employee1");
            DropTable("dbo.Title");
            DropTable("dbo.MaritalStatus");
            DropTable("dbo.Gender");
            DropTable("dbo.Designation");
            DropTable("dbo.Department");
            DropTable("dbo.Branch");
            DropTable("dbo.Employee");
            DropTable("dbo.AdvancePayment");
        }
    }
}
