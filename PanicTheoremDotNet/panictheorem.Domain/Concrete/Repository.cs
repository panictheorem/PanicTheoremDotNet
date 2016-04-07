using System;
using System.Collections.Generic;
using System.Data.Entity;
using panictheorem.Domain.Abstract;
using panictheorem.Domain.Concrete;
namespace RepoAndUnitOfWork.Domain.Concrete
{
    public class Repository<T> : IRepository<T>, IDisposable where T : IEntity
    {
        protected PanicTheoremDbContext dbContext;

        protected DbSet<T> dbSet;

        public Repository(PanicTheoremDbContext context)
        {
            dbContext = context;
            dbSet = context.Set<T>();
        }

        public virtual IEnumerable<T> Rows { get { return dbSet; } }

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual T GetById(int? id)
        {
            return dbSet.Find(id);
        }

        public virtual void Update(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}