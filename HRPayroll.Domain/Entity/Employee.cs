using System;
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
        [Required]
        public int TitleId { get; set; }
        [ForeignKey("TitleId")]
        public Title Title { get; set; }
         [Required]
        public int GenderId { get; set; }
        [ForeignKey("GenderId")]
        public Gender Gender { get; set; }
        [Required]
        public int DesignationId { get; set; }
         [ForeignKey("DesignationId")]
        public virtual Designation Designation { get; set; }
         [Required]
        
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
         [Required]
        public int ReligionId { get; set; }
         [ForeignKey("ReligionId")]
         public virtual Religion Religion { get; set; }
        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
         [Required]
        public int MaritalStatusId { get; set; }
        [ForeignKey("MaritalStatusId")]
        public MaritalStatus MaritalStatus { get; set; }

        public DateTime Dob { get; set; }
        public string FathersName { get; set; }
        public int CitizenShipNo { get; set; }


        [EmailAddress]
        [Required]
        public string EmailId { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
    }
}