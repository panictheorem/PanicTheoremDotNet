using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace panictheorem.Domain.Abstract
{
    public interface IRepository<T> : IDisposable where T : IEntity
    {
        IEnumerable<T> Rows { get; }
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T GetById(int? id);
    }
}
