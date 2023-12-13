using WebAPI.Core.Repository;
using WebAPI.Entities.Concrete;
using WebAPI.Entities.DTO_s;

namespace WebAPI.DataAccess.Abstract
{
    public interface IContactDal : IRepository<Contact>
    {
        //Special methods for contact.
        List<ContactDTO> GetContactsWithCompanyAndCountry();
        List<ContactDTO> FilterContact(int companyId, int countryId);

    }
}
