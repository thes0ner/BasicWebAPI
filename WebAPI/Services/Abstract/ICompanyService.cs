using WebAPI.Entities.Concrete;

namespace WebAPI.Services.Abstract
{
    public interface ICompanyService
    {
        Task<Company> GetByIdAsync(int id);
        Task<IEnumerable<Company>> GetAllAsync();
        Task<Company> CreateAsync(Company company);
        Task<Company> UpdateAsync(Company company);
        Task DeleteAsync(int id);
        Task SaveAsync();

    }
}
