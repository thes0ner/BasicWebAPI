using System.Collections;
using System.Linq.Expressions;

namespace WebAPI.Repository
{
    public interface IRepository<T> where T : class
    {
        T Get(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null);
        void Create(T entity);
        T Update(T entity);
        void Delete(int id);
    }
}
