using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using HRPayroll.Data.Infrastructure;
using HRPayroll.Domain.Entity;

namespace HRPayroll.Data
{
    public class EmployeeRepository :RepositoryBase<Employee>
    {
        public override IEnumerable<Employee> GetAll()
        {
            return base.dbset.Include(e => e.Branch).Include(e => e.Department).Include(e => e.Designation).Include(e => e.Title);
        }
    }
}