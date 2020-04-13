using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MRS_Store.Models.Services
{
    public interface IDataService<T>
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> expression);
        T Get(Int64 id);
        T Get(Expression<Func<T, bool>> expression);
        T Create(T entity);
        T Update(Int64 id,T entity);
        bool Delete(Int64 id);
    }
}
