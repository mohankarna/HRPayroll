using System.Collections.Generic;

namespace HRPayroll.Service
{
    public interface IServiceCommand<T>
    {
        T Add(T entity);
        T Update(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();

        T GetById(int id); 
    }
}