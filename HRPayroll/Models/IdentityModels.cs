using HRPayroll.Domain.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HRPayroll.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<HRPayroll.Domain.Entity.Student> Students { get; set; }

        public System.Data.Entity.DbSet<HRPayroll.Domain.Entity.Designation> Designations { get; set; }

        public System.Data.Entity.DbSet<HRPayroll.Domain.Entity.Department> Departments { get; set; }

        public System.Data.Entity.DbSet<HRPayroll.Domain.Gender> Genders { get; set; }

        public System.Data.Entity.DbSet<HRPayroll.Domain.Entity.Branch> Branches { get; set; }

        public System.Data.Entity.DbSet<HRPayroll.Domain.Ethenic> Ethenics { get; set; }

        public System.Data.Entity.DbSet<HRPayroll.Domain.Qualification> Qualifications { get; set; }

        public System.Data.Entity.DbSet<Title> Titles { get; set; }

        public System.Data.Entity.DbSet<HRPayroll.Domain.ServiceType> ServiceTypes { get; set; }

        public System.Data.Entity.DbSet<HRPayroll.Domain.Entity.Employee> Employees { get; set; }

        public System.Data.Entity.DbSet<HRPayroll.Domain.Entity.MaritalStatus> MaritalStatus { get; set; }

        public System.Data.Entity.DbSet<HRPayroll.Domain.Entity.PayPlanSetup> PayPlanSetups { get; set; }

        public System.Data.Entity.DbSet<HRPayroll.Domain.Entity.LeaveType> LeaveSetups { get; set; }

        public System.Data.Entity.DbSet<HRPayroll.Domain.Entity.TaxSetup> TaxSetups { get; set; }

        public System.Data.Entity.DbSet<HRPayroll.Domain.Entity.HrGlobalSetup> HrGlobalSetups { get; set; }

        public System.Data.Entity.DbSet<HRPayroll.Domain.Entity.LeaveRequest> LeaveRequests { get; set; }

        public System.Data.Entity.DbSet<HRPayroll.Domain.Entity.LeaveReport> LeaveReports { get; set; }
    }
}