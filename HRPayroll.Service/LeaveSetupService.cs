using HRPayroll.Data;
using HRPayroll.Domain.Entity;
using HRPayroll.Service.Infrastructure;

namespace HRPayroll.Service
{
    public class LeaveSetupService : ServiceBase<LeaveType>
    {

        public LeaveSetupService()
            : base(new LeaveSetupRepository())
        {

        }
    }
}