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

        public double BasicSalary { get; set; }

        public double PreviousGrade { get; set; }

        public double CurrentGrade { get; set; }

        public double DearnessAllowance { get; set; }

        public double HouseRent { get; set; }

        public double TiffinAllowance { get; set; }

        public double SpecialAllowance { get; set; }

        public double MedicalAllowance { get; set; }

        public double OtherAllowance { get; set; }
        public double PF { get; set; }
        public double CommunicationAllowance { get; set; }
        public double DashainAllowance { get; set; }
        public double DonationFund { get; set; }
        public double CIT { get; set; }
        public double Insurance { get; set; }

        public MonthlySalaryDetail()
        {
            Holidays = 0;
            PayDays = 0;
            PF = 0;
            PfAdded = 0;
            AbsentDays = 0;
            OTHours = 0;
        }
        
    }
}