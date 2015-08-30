using HRPayroll.Data;
using HRPayroll.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPayroll.Service
{
    public class Employee1service : IServiceCommand<Employee1>
    {
        private readonly Employee1Repository repository;
        public Employee1service()
        {
            repository = new Employee1Repository();
        }
        public Employee1 Add(Employee1 entity)
        {
            return repository.Add(entity);
        }

        public Employee1 Update(Employee1 entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Employee1 entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee1> GetAll()
        {
            return repository.GetAll();
        }

        public Employee1 GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
