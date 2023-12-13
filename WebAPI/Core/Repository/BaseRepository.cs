
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAPI.Core.Entities;
using WebAPI.DataAccess.Concrete.context;
using WebAPI.Entities.Concrete;

namespace WebAPI.Core.Repository
{
    public class BaseRepository<T, TContext> : IRepository<T>
        where T : class, IEntity
        where TContext : WebApiDbContext, new()
    {

        public T Get(Expression<Func<T, bool>> filter)
        {
            using (var _dbContext = new WebApiDbContext())
            {
                return _dbContext.Set<T>().SingleOrDefault(filter);
            }

        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            using (var _dbContext = new WebApiDbContext())
            {
                if (filter == null)
                    return _dbContext.Set<T>().ToList();
                else
                    return _dbContext.Set<T>().Where(filter).ToList();
            }
        }

        public void Create(T entity)
        {
            using (var _dbContext = new WebApiDbContext())
            {
                var addedEntity = _dbContext.Add(entity);
                addedEntity.State = EntityState.Added;
                _dbContext.SaveChanges();

            }
        }

        public void Delete(int id)
        {
            using (var _dbContext = new WebApiDbContext())
            {

                var entity = _dbContext.Set<T>().Find(id);

                if (entity != null)
                {
                    _dbContext.Entry(entity).State = EntityState.Deleted;
                    _dbContext.SaveChanges();
                }
            }

        }

        public T Update(T entity)
        {
            using (var _dbContext = new WebApiDbContext())
            {
                var updatedEntity = _dbContext.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                _dbContext.SaveChanges();

                return entity;

            }

        }
    }
}
