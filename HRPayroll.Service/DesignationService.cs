using System.Collections.Generic;
using HRPayroll.Data;
using HRPayroll.Domain.Entity;
using HRPayroll.Service.Infrastructure;

namespace HRPayroll.Service
{
    public class DesignationService : ServiceBase<Designation>
    { 

         public DesignationService()
             : base(new DesignationRepository())
        {
        }

      
    }
}