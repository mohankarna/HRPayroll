using System.Collections.Generic;
using HRPayroll.Data;
using HRPayroll.Domain.Entity;
using HRPayroll.Service.Infrastructure;

namespace HRPayroll.Service
{
    public class EmployeeService : ServiceBase<Employee>
    {


        public EmployeeService()
            : base(new EmployeeRepository())
        {
        }

       
    }
}