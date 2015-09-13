using HRPayroll.Data;
using HRPayroll.Data.Infrastructure;
using HRPayroll.Domain.Entity;
using HRPayroll.Service.Infrastructure;

namespace HRPayroll.Service
{
    public class RolesService:ServiceBase<Roles>
    {
        public RolesService()
            : base(new RolesRepository())
        {
        }
    }
}