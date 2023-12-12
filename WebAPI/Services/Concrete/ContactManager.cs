using Microsoft.EntityFrameworkCore;
using WebAPI.DataAccess.Abstract;
using WebAPI.Entities.Concrete;
using WebAPI.Services.Abstract;

namespace WebAPI.Services.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public async Task<Contact> CreateAsync(Contact contact)
        {
            await _contactDal.CreateAsync(contact);
            await _contactDal.SaveAsync();
            return contact;
        }

        public async Task DeleteAsync(int id)
        {
            var result = _contactDal.GetByIdAsync(id);

            try
            {
                if (result != null)
                {
                    await _contactDal.DeleteAsync(id);
                    await _contactDal.SaveAsync();
                }
            }
            catch
            {
                await Console.Out.WriteLineAsync($"Entered Id {id} not found in the list.");
            }
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await _contactDal.GetAllAsync();
        }

        public async Task<Contact> GetByIdAsync(int id)
        {
            return await _contactDal.GetByIdAsync(id);
        }

        public async Task SaveAsync()
        {
            await _contactDal.SaveAsync();
        }

        public async Task<Contact> UpdateAsync(Contact contact)
        {
            await _contactDal.UpdateAsync(contact);
            await _contactDal.SaveAsync();
            return contact;

        }
    }
}
