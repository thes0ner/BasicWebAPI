using WebAPI.DataAccess.Abstract;
using WebAPI.DataAccess.Concrete;
using WebAPI.Entities.Concrete;
using WebAPI.Services.Abstract;

namespace WebAPI.Services.Concrete
{
    public class CompanyManager : ICompanyService
    {
        private readonly ICompanyDal _companyDal;

        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }

        public async Task<Company> CreateAsync(Company company)
        {
            _companyDal.CreateAsync(company);
            await _companyDal.SaveAsync();
            return company;
        }

        public async Task DeleteAsync(int id)
        {
            var result = _companyDal.GetByIdAsync(id);

            try
            {
                if (result != null)
                {
                    _companyDal.DeleteAsync(result.Id);
                    await _companyDal.SaveAsync();
                }
            }
            catch
            {
                await Console.Out.WriteLineAsync($"Entered Id {id} not found in the list.");
            }
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await _companyDal.GetAllAsync();
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            return await _companyDal.GetByIdAsync(id);
        }

        public async Task<Company> UpdateAsync(Company company)
        {
            await _companyDal.UpdateAsync(company);
            await _companyDal.SaveAsync();
            return company;
        }
        public async Task SaveAsync()
        {
            await _companyDal.SaveAsync();
        }
    }
}
