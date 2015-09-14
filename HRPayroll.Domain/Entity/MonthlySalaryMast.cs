using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRPayroll.Domain.Entity
{
    public class MonthlySalaryMast
    {
        public int Id { get; set; }

        public int Totaldaysinmonth { get; set; }

        public double Otrate { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }


        public DateTime Fromdate
        {
            get;
            set;
        }

        public int Branchid { get; set; }
        [ForeignKey("Branchid")]
        public Branch Branch { get; set; }

        private DateTime? _createddate = Convert.ToDateTime("01/01/1991");
        public DateTime? Createddate
        {
            get { return _createddate; }
            set { _createddate = value; }
        }

        public bool SendForApproval { get; set; }
        public bool Approved { get; set; }
        public int ApprovedBy { get; set; }
        public DateTime ApprovedDate { get; set; }

        public List<MonthlySalaryDetail> MonthlySalaryDetails { get; set; }
    }
}