using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HRPayroll.Data.Infrastructure;

namespace HRPayroll.Service.Infrastructure
{
    public class ServiceBase<T> where T : class  
    {
        protected RepositoryBase<T> repositoryBase;
        public ServiceBase(RepositoryBase<T> repo)
        {
            repositoryBase = repo;
        }
        public virtual T Add(T entity)
        {
            return repositoryBase.Add(entity);
        }

        public virtual T Update(T entity)
        {
            return repositoryBase.Update(entity);
        }

        public virtual void Delete(T entity)
        {
            repositoryBase.Delete(entity);
        }
        public virtual T GetById(string id)
        {
            return repositoryBase.GetById(id);
        }
        public virtual T GetById(long id)
        {
            return repositoryBase.GetById(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return repositoryBase.GetAll();
        }
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return repositoryBase.GetMany(where);
        }
        public virtual IEnumerable<T> GetManyWithInclude(Expression<Func<T, bool>> where, string include)
        {
            return repositoryBase.GetManyWithInclude(where, include);
        }
        public T Get(Expression<Func<T, bool>> where)
        {
            return repositoryBase.Get(where);
        }
    }
}
