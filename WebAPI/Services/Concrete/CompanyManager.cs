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

        public int Create(Company company)
        {
            _companyDal.Create(company);
            return company.CompanyId;
        }

        public void Delete(int id)
        {
            var result = _companyDal.Get(c => c.CompanyId == id);
            if (result != null)
            {
                _companyDal.Delete(id);
            }
        }

        public Company Update(Company company)
        {

            var updatedEntity = _companyDal.Update(company);
            return updatedEntity;

        }

        public IEnumerable<Company> GetAll()
        {
            return _companyDal.GetAll();
        }

        public Company GetById(int id)
        {
            return _companyDal.Get(c => c.CompanyId == id);
        }


    }
}
