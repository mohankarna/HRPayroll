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
        public decimal BasicSalary { get; set; }
        public decimal PreviousGrade { get; set; }
        public decimal CurrentGrade { get; set; }
        public decimal SpecialAllow { get; set; }
        public decimal DearnessAllow { get; set; }
        public decimal OtherAllow { get; set; }
        public decimal CIT { get; set; }
        public decimal Insurance { get; set; }
    }
}