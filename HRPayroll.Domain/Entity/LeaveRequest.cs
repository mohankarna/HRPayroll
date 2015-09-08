using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPayroll.Domain.Entity
{
   public class LeaveRequest
    {
      
      public int Id { get; set; }
       
      public int LeaveTypeId { get; set; }
        [ForeignKey("LeaveTypeId")]
       public LeaveType LeaveType { get; set; }
       
        public DateTime Date { get; set; }
       public DateTime LeaveFrom { get; set; }
       public DateTime LeaveTo { get; set; }
       public int TotalDays { get; set; }
       public string Reason { get; set; }
       public bool IsHalfDay { get; set; }
       public int EmployeeId { get; set; }
       [ForeignKey("EmployeeId")]
       public Employee Employee { get; set; }
    }
}
