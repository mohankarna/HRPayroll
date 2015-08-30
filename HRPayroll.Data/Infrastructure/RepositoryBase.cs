using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace HRPayroll.Data.Infrastructure
{
    public class RepositoryBase<T> where T : class
    {
        private DatabaseContext dataContext;
        protected readonly IDbSet<T> dbset;
        protected RepositoryBase()
        {
            databaseFactory= new DatabaseFactory();
            dbset = DataContext.Set<T>();
        }

        private DatabaseFactory databaseFactory;
       
        protected DatabaseContext DataContext
        {
            get { return dataContext ?? (dataContext = databaseFactory.Get()); }
        }

        public virtual T Add(T entity)
        {
            entity = dbset.Add(entity);
            dataContext.SaveChanges();
            return entity;
        }

        public virtual T Update(T entity)
        {
            dbset.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
            dataContext.SaveChanges();
            return entity;
        }

        public virtual void Delete(T entity)
        {
            dbset.Remove(entity);
            dataContext.SaveChanges();
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbset.Remove(obj);
            dataContext.SaveChanges();
        }

        public virtual T GetById(long id)
        {
            return dbset.Find(id);
        }

        public virtual T GetById(string id)
        {
            return dbset.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).ToList();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).FirstOrDefault<T>();
        }
    }
}