using System.ComponentModel.DataAnnotations;

namespace HRPayroll.Domain.Entity
{
    public class Department
    {
        public int Id { get; set; } 
        [Required]
        [StringLength(100)]
        public string DepartmentName { get; set; }

        public string DepartmnentChief { get; set; }

    }
}