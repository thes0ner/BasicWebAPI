using WebAPI.Entities.Concrete;

namespace WebAPI.Services.Abstract
{
    public interface IContactService
    {
        Contact GetById(int id);
        IEnumerable<Contact> GetAll();
        int Create(Contact contact);
        Contact Update(Contact contact);
        void Delete(int id);

        //Task<IEnumerable<Contact>> FilterContactsAsync(int? countryId, int? companyId);
        //GetContactsWithCompanyAndCountry();
    }
}
