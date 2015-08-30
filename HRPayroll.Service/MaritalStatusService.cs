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
    public class MaritalStatusService : ServiceBase<MaritalStatus>
    {

        public MaritalStatusService()
            : base(new MaritalStatusRepository())
        {
        }

    
    }
}
