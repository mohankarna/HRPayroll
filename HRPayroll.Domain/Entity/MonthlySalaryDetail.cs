using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRPayroll.Domain.Entity
{
    public class MonthlySalaryDetail
    {
        public int Id { get; set; }

        public int MonthlyMastId { get; set; }
        [ForeignKey("MonthlyMastId")]

        public MonthlySalaryMast MonthlySalaryMast { get; set; }
        public int EmpId { get; set; }
        [ForeignKey("EmpId")]
        public Employee Employee { get; set; }

        public double AttendanceDays { get; set; }

        public double Holidays { get; set; }

        public double LeaveDays { get; set; }

        public double AbsentDays { get; set; }

        public double PayDays { get; set; }



        public double OTHours { get; set; }

        public double OTAmount { get; set; }



        public double SSTax { get; set; }

        public double IncomeTax { get; set; }

        public double Advance { get; set; }
        public double OtherAdvance { get; set; }


        public double OtherDeduct { get; set; }


        public double Total { get; set; }
        public double NetTotal { get; set; }

        public double PfAdded { get; set; }
        public double TotalPF { get; set; }
        public List<MonthlySalaryDetail> MonthlySalaryDetailslst;
    }
}