using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPayroll.Domain.Entity;

namespace HRPayroll.Domain.ViewModel
{
    public class WorkingDays
    {
        public int Totaldaysinmonth { get; set; }

        public int Branchid { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }


        public WorkingDaysDetails[] WorkingDaysDetails { get; set; }
    }
}
