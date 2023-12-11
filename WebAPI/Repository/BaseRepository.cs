
using Microsoft.EntityFrameworkCore;
using WebAPI.DataAccess.Concrete.context;

namespace WebAPI.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly WebApiDbContext _dbContext;

        public BaseRepository(WebApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateAsync(T entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _dbContext.FindAsync<T>(id);

            if (data != null)
            {
                _dbContext.Remove(data);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.FindAsync<T>(id);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
