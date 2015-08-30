using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRPayroll.Domain.Entity
{
    [Table("Employee")]
    public class Employee
    {
        public int Id { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]


        [Display(Name = "Employee Name")]
        public string EmployeeName { get; set; }
        public int TitleId { get; set; }
        [ForeignKey("TitleId")]
        public Title Title { get; set; }
        public int GenderId { get; set; }
        [ForeignKey("GenderId")]
        public Gender Gender { get; set; }
       
        public int DesignationId { get; set; }
         [ForeignKey("DesignationId")]
        public virtual Designation Designation { get; set; }

        
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
        public int MaritalStatusId { get; set; }
        [ForeignKey("MaritalStatusId")]
        public MaritalStatus MaritalStatus { get; set; }

        [EmailAddress]
        [RegularExpression("[]")]
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
    }
}