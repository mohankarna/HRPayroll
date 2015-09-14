using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRPayroll.Domain.Entity
{
    public class Users
    {
        public int Id { get; set; }

        [StringLength(100)]
        [Required]
        public string UserName { get; set; }

        [StringLength(200)]
        [Required]
        public string Password { get; set; }


        [ForeignKey("EmployeeId")]
      
        public Employee Employee { get; set; }
          [Required]
        public int EmployeeId { get; set; }
          [Required]
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        
        public Roles Roles { get; set; }
    }
}