using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using HRPayroll.Domain;
using HRPayroll.Domain.Entity;

namespace HRPayroll.Data.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("DefaultConnection")
        {
            // ROLA - This is a hack to ensure that Entity Framework SQL Provider is copied across to the output folder.
            // As it is installed in the GAC, Copy Local does not work. It is required for probing.
            // Fixed "Provider not loaded" error
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TaxSetup> TaxSetups { get; set; }


        
        public DbSet<Student> Students { get; set; }

        public DbSet<Employee1> Employee1s { get; set; }
        public DbSet<Designation> Designations{ get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Gender> Genders { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<Ethenic> Ethenics { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public DbSet<PayPlanSetup> PayPlanSetups { get; set; }
        public DbSet<LeaveType> LeaveSetups { get; set; }
        public DbSet<HrGlobalSetup> HrGlobalSetups { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<LeaveReport> LeaveReports { get; set; }

        public DbSet<WorkingDaysEntry> WorkingDaysEntries { get; set; }
        public DbSet<AdvancePayment> AdvancePayments { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<MonthlySalaryMast> MonthlySalaryMast { get; set; }
        public DbSet<MonthlySalaryDetail> MonthlySalaryDetails { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DatabaseContext>(null);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
    }
}