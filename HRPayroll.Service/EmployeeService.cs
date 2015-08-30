using System.Collections.Generic;
using HRPayroll.Data;
using HRPayroll.Domain.Entity;

namespace HRPayroll.Service
{
    public class EmployeeService : IServiceCommand<Employee>
    {
        private readonly EmployeeRepository repository;

        public EmployeeService()
        {
            this.repository = new EmployeeRepository();
        }

        public Employee Add(Employee entity)
        {
            return repository.Add(entity);
        }

        public Employee Update(Employee entity)
        {
            return repository.Update(entity);
        }

        public void Delete(Employee entity)
        {
            repository.Delete(entity);
        }

        public IEnumerable<Employee> GetAll()
        {
            return repository.GetAll();
        }

        public Employee GetById(int id)
        {
            return repository.GetById(id);
        }
    }
}