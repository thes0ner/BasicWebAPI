using Microsoft.EntityFrameworkCore;
using WebAPI.DataAccess.Abstract;
using WebAPI.DataAccess.Concrete.context;
using WebAPI.Entities.Concrete;
using System.Linq;
using WebAPI.Core.Repository;
using WebAPI.Entities.DTO_s;

namespace WebAPI.DataAccess.Concrete
{
    public class EfContactDal : BaseRepository<Contact, WebApiDbContext>, IContactDal
    {
        public List<ContactDTO> FilterContact(int companyId, int countryId)
        {
            using (var _dbContext = new WebApiDbContext())
            {
                return (from contact in _dbContext.Contacts
                        where contact.CompanyId == companyId && contact.CountryId == countryId
                        select new ContactDTO
                        {
                            CompanyId = contact.CompanyId,
                            CountryId = contact.CountryId,
                            CompanyName = contact.Company.CompanyName,
                            ContactName = contact.ContactName,
                            CountryName = contact.Country.CountryName
                        }).ToList();
            }
        }

        public List<ContactDTO> GetContactsWithCompanyAndCountry()
        {
            using (var _dbContext = new WebApiDbContext())
            {
                var result = from contact in _dbContext.Contacts
                             join company in _dbContext.Companies on contact.CompanyId equals company.CompanyId
                             join country in _dbContext.Countries on contact.CountryId equals country.CountryId
                             select new ContactDTO
                             {
                                 CompanyId = company.CompanyId,
                                 CountryId = country.CountryId,
                                 CompanyName = company.CompanyName,
                                 ContactName = contact.ContactName,
                                 CountryName = country.CountryName,
                             };

                return result.ToList();

            }



        }
    }
}
