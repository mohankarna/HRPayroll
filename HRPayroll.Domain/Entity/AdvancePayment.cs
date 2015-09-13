using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPayroll.Domain.Entity;
using HRPayroll.Domain;

namespace HRPayroll.Domain.Entity
{
    public class AdvancePayment
    {
        public int Id { get; set; }

    //    public int BranchId{ get; set; }
    //[ForeignKey("BranchId")]
    //    public Branch Branch { get; set; }
        
        public int EmployeeId { get; set; }
        
        public Employee Employee { get; set; }
        public decimal SalaryAdvance { get; set; }
        public decimal OtherAdvance { get; set; }
        public String Purpose { get; set; }
        public string PaymentMode { get; set; }
        public String Bank { get; set; }

    }
}
