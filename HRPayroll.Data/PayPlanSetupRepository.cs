using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRPayroll.Data.Infrastructure;
using HRPayroll.Domain.Entity;

namespace HRPayroll.Data
{
    public class PayPlanSetupRepository : RepositoryBase<PayPlanSetup>
    {
        public override IEnumerable<PayPlanSetup> GetAll()
        {
            return base.dbset.Include(e => e.Employee);
        }
    }
}
