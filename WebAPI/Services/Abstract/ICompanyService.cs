using WebAPI.Entities.Concrete;

namespace WebAPI.Services.Abstract
{
    public interface ICompanyService
    {
        Company GetById(int id);
        IEnumerable<Company> GetAll();
        int Create(Company company);
        Company Update(Company company);
        void Delete(int id);

    }
}
