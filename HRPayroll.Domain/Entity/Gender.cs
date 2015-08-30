using System.ComponentModel.DataAnnotations;

namespace HRPayroll.Domain
{
    public class Gender
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string GenderName { get; set; }
        
       
       
    }
}