using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPayroll.Domain.Entity
{
    public class HrGlobalSetup
    {
        public int Id { get; set; }
        public static int WorkingHrsPerDay  { get; set; }
        public static Decimal OtRate { get; set; }

        public HrGlobalSetup()
        {
            WorkingHrsPerDay = 8;
            OtRate = (decimal) 1.50;
        }
         
    }
}
