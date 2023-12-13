
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebAPI.DataAccess.Concrete.context;
using WebAPI.Entities.Concrete;

namespace WebAPI.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly WebApiDbContext _dbContext;
        //protected virtual DbSet<T> DbSet { get; }

        public BaseRepository(WebApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _dbContext.Set<T>().SingleOrDefault(filter);

        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            if (filter == null)
                return _dbContext.Set<T>().ToList();
            else
                return _dbContext.Set<T>().Where(filter).ToList();
        }

        public void Create(T entity)
        {
            var addedEntity = _dbContext.Add(entity);
            addedEntity.State = EntityState.Added;
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = _dbContext.Set<T>().Find(id);

            if (entity != null)
            {
                _dbContext.Entry(entity).State = EntityState.Deleted;
                _dbContext.SaveChanges();
            }
        }

        public T Update(T entity)
        {
            var updatedEntity = _dbContext.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            _dbContext.SaveChanges();

            return entity;
        }
    }
}
