using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsProyectDI.Abstractions
{
    public interface IBaseRepository<T> : IDisposable where T : TableData, new()
    {
        void Save(T item);
        void Delete(T item, bool recursive = true);
        T? GetById(int id);
        T? GetByExpression(Expression<Func<T, bool>> predicate);
        List<T> GetAll();
        List<T> GetAll(Expression<Func<T, bool>> predicate);

    }
}
