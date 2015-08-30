using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRPayroll.Domain.Entity
{
    public class Designation
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
       
        public string DesignationName { get; set; }

        [StringLength(200)]
       
        public string Description { get; set; }
    }
}