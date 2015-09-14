using System.Collections.Generic;
using System.Data.Entity;
using HRPayroll.Data.Infrastructure;
using HRPayroll.Domain.Entity;

namespace HRPayroll.Data
{
    public class UsersRepository : RepositoryBase<Users>
    {
        public override IEnumerable<Users> GetAll()
        {
            return base.dbset.Include(e => e.Employee).Include(e => e.Roles);
        }
    }
}