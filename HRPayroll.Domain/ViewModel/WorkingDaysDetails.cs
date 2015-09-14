using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPayroll.Domain.ViewModel
{
    public class WorkingDaysDetails
    {
        public int EmpId { get; set; }
        public int AttendanceDays { get; set; }

        public int Holidays { get; set; }

        public int LeaveDays { get; set; }

        public int AbsentDays { get; set; }

        public int PayDays { get; set; }

        public int OTHours { get; set; }
    }
}
