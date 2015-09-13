using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPayroll.Data;
using HRPayroll.Domain.Entity;
using HRPayroll.Service.Infrastructure;

namespace HRPayroll.Service
{
    public class WorkingDaysEntryService : ServiceBase<WorkingDaysEntry>
    {
        public WorkingDaysEntryService()
            : base(new WorkingDaysEntryRepository())
        {

        }
        //public override WorkingDaysEntry Add(List<WorkingDaysEntry> entity)
        //{
            
        //    foreach (var en in entity)
        //    {
        //        base.Add(en);
        //    }
        //    base.Add(en);
        //}
    }
}
