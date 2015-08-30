using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using HRPayroll.Data.Infrastructure;
using HRPayroll.Domain.Entity;

namespace HRPayroll.Data
{
    public class LeaveRequestRepository : RepositoryBase<LeaveRequest>
    {
        public override IEnumerable<LeaveRequest> GetAll()
        {
            return base.dbset.Include(e => e.Employee).Include(e => e.LeaveType);
        }

      
    }
}
