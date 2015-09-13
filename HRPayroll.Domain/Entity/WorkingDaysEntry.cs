using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPayroll.Domain.Entity
{
   public class WorkingDaysEntry
    {
       public int Id { get; set; }
       public int BranchId { get; set; }
       public Branch Branch { get; set; }
       public DateTime Year { get; set; }
       public string Month { get; set; }
       public int TotalDaysInMonth { get; set; }
    }
}
