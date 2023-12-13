using System.Collections;
using System.Linq.Expressions;
using WebAPI.Core.Entities;

namespace WebAPI.Core.Repository
{
    public interface IRepository<T> where T : class, IEntity
    {
        T Get(Expression<Func<T, bool>> filter);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null);
        void Create(T entity);
        T Update(T entity);
        void Delete(int id);
    }
}
