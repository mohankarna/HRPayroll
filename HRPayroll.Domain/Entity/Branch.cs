using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPayroll.Domain.Entity
{
   public class Branch
    {
        public int Id { get; set; }
       [Required]
       [StringLength(150)]
        public string BranchName { get; set; }
    }
}
