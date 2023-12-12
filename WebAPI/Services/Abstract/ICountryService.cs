using WebAPI.Entities.Concrete;

namespace WebAPI.Services.Abstract
{
    public interface ICountryService
    {
        Task<Country> GetByIdAsync(int id);
        Task<IEnumerable<Country>> GetAllAsync();
        Task<Country> CreateAsync(Country country);
        Task UpdateAsync(Country country);
        Task DeleteAsync(int id);
        Task SaveAsync();

    }
}
