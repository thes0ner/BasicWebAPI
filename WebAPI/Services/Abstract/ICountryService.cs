using WebAPI.Entities.Concrete;

namespace WebAPI.Services.Abstract
{
    public interface ICountryService
    {
        Country GetById(int id);
        IEnumerable<Country> GetAll();
        int Create(Country contact);
        Country Update(Country contact);
        void Delete(int id);
    }
}
