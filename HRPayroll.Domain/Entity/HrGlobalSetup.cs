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
        public int WorkingHrsPerDay { get; set; }
        public Decimal OtRate { get; set; }
    }
}
