using WebAPI.DataAccess.Abstract;
using WebAPI.DataAccess.Concrete;
using WebAPI.Entities.Concrete;
using WebAPI.Services.Abstract;

namespace WebAPI.Services.Concrete
{
    public class CountryManager : ICountryService
    {
        private readonly ICountryDal _countryDal;

        public CountryManager(ICountryDal countryDal)
        {
            _countryDal = countryDal;
        }

        public async Task<Country> CreateAsync(Country country)
        {
            await _countryDal.CreateAsync(country);
            await _countryDal.SaveAsync();
            return country;
        }

        public async Task DeleteAsync(int id)
        {
            var result = _countryDal.GetByIdAsync(id);

            try
            {
                if (result != null)
                {
                    await _countryDal.DeleteAsync(id);
                    await _countryDal.SaveAsync();
                }
            }
            catch
            {
                await Console.Out.WriteLineAsync($"Entered Id {id} not found in the list.");
            }
        }

        public async Task<IEnumerable<Country>> GetAllAsync()
        {
            return await _countryDal.GetAllAsync();
        }

        public async Task<Country> GetByIdAsync(int id)
        {
            return await _countryDal.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Country country)
        {
            await _countryDal.UpdateAsync(country);
            await _countryDal.SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _countryDal.SaveAsync();
        }
    }
}
