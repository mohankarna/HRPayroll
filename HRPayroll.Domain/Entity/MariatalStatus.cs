using System.ComponentModel.DataAnnotations;

namespace HRPayroll.Domain.Entity
{
    public class MaritalStatus
    {
        public int   Id { get; set; } 
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}