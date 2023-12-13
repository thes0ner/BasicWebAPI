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

        public int Create(Country country)
        {
            _countryDal.Create(country);
            return country.CountryId;
        }

        public void Delete(int id)
        {
            var result = _countryDal.Get(c => c.CountryId == id);
            if (result != null)
            {
                _countryDal.Delete(id);
            }
        }

        public Country Update(Country country)
        {
            var checkExistingId = _countryDal.Get(c => c.CountryId == country.CountryId);

            if (checkExistingId == null)
            {
                return country;
            }
            else
            {
                var updatedEntity = _countryDal.Update(country);
                return updatedEntity;

            }

        }

        public IEnumerable<Country> GetAll()
        {
            return _countryDal.GetAll();
        }

        public Country GetById(int id)
        {
            return _countryDal.Get(c => c.CountryId == id);
        }

    }
}
