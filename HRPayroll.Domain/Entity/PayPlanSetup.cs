using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRPayroll.Domain.Entity
{
    public class PayPlanSetup
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        [Required]
        public double BasicSalary { get; set; }

        public double PreviousGrade { get; set; }

        public double CurrentGrade { get; set; }

        public double DearnessAllowance { get; set; }

        public double HouseRent { get; set; }

        public double TiffinAllowance { get; set; }

        public double SpecialAllowance { get; set; }

        public double MedicalAllowance { get; set; }

        public double OtherAllowance { get; set; }
        public double PF { get; set; }
        public double CommunicationAllowance { get; set; }
        public double DashainAllowance { get; set; }
        public double DonationFund { get; set; }
        public double CIT { get; set; }
        public double Insurance { get; set; }
    }
}