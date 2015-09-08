using System.ComponentModel.DataAnnotations.Schema;

namespace HRPayroll.Domain.Entity
{
    
    public class LeaveType
    {
        public int Id { get; set; }
        public string LeaveName { get; set; }
        public string LeaveDescription { get; set; }
        public int AllowedPerYear { get; set; }

        public int ServiceTypeId { get; set; }
        [ForeignKey("ServiceTypeId")]
        public ServiceType ServiceType { get; set; }

        public int EthenicId { get; set; }
        [ForeignKey("EthenicId")]
        public Ethenic Ethenic { get; set; }

        public int MaritalStatusId { get; set; }
          [ForeignKey("MaritalStatusId")]
        public MaritalStatus MaritalStatus { get; set; }

        public int GenderId { get; set; }
        [ForeignKey("GenderId")]
        public Gender Gender { get; set; }

        public bool AllowHalfDay { get; set; }

        public bool IsPayable { get; set; }
    }
}