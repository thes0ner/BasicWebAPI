using WebAPI.Entities.Concrete;

namespace WebAPI.Services.Abstract
{
    public interface IContactService
    {
        Task<Contact> GetByIdAsync(int id);
        Task<IEnumerable<Contact>> GetAllAsync();
        Task<Contact> CreateAsync(Contact contact);
        Task<Contact> UpdateAsync(Contact contact);
        Task DeleteAsync(int id);
        Task SaveAsync();

        //Task<IEnumerable<Contact>> FilterContactsAsync(int? countryId, int? companyId);
        //GetContactsWithCompanyAndCountry();
    }
}
