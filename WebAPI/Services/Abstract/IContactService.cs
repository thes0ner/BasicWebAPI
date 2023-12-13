using WebAPI.Entities.Concrete;
using WebAPI.Entities.DTO_s;

namespace WebAPI.Services.Abstract
{
    public interface IContactService
    {
        Contact GetById(int id);
        IEnumerable<Contact> GetAll();
        int Create(Contact contact);
        Contact Update(Contact contact);
        void Delete(int id);

        List<ContactDTO> GetContactsWithCompanyAndCountry();
        List<ContactDTO> FilterContact(int companyId, int countryId);
    }
}
