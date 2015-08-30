using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPayroll.Domain.Entity
{
   public class LeaveReport
    {
       public int Id { get; set; }
       public string Branch { get; set; }
       public DateTime From { get; set; }
       public DateTime To { get; set; }
    }
}
