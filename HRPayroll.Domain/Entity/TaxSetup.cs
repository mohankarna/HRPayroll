using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPayroll.Domain.Entity
{
   public class TaxSetup
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Column("VARCHAR")]
        public string TaxDescription { get; set; }
        [Required]
        public decimal From { get; set; }
        [Required]
        public decimal To { get; set; }
        [Required]
        public decimal Rate { get; set; }
      public int MaritalStatusId { get; set; }
       [ForeignKey("MaritalStatusId")]
       public MaritalStatus MaritalStatus { get; set; }
       
    }
}
