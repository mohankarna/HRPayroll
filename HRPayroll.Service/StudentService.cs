using HRPayroll.Data;
using HRPayroll.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPayroll.Service
{
    public class StudentService : IServiceCommand<Student>
    {
        private readonly StudentRepository repository;
        public StudentService()
        {
            repository = new StudentRepository();
        }
        public Student Add(Student entity)
        {
            return repository.Add(entity);
        }

        public Student Update(Student entity)
        {
            return repository.Update(entity);
        }

        public void Delete(Student entity)
        {
            repository.Delete(entity);
        }

        public IEnumerable<Student> GetAll()
        {
            return repository.GetAll();
        }

        public Student GetById(int id)
        {
            return repository.GetById(id);
        }
    }
}
