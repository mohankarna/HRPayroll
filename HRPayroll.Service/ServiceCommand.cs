using System.Collections.Generic;
using HRPayroll.Data.Infrastructure;

namespace HRPayroll.Service
{
    public class ServiceCommand<T,C> where C:RepositoryBase<T>, new() where T:class 
    {
      
       

        //T Update(T entity);
        //void Delete(T entity);
        //IEnumerable<T> GetAll();

        //T GetById(int id);
    }
}