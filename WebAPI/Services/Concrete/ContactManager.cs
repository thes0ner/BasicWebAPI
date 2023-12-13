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

        public int Create(Contact contact)
        {
            _contactDal.Create(contact);
            return contact.ContactId;
        }

        public void Delete(int id)
        {
            var result = _contactDal.Get(c => c.ContactId == id);
            if (result != null)
            {
                _contactDal.Delete(id);
            }
        }

        public Contact Update(Contact contact)
        {
            var updatedEntity = _contactDal.Update(contact);
            return updatedEntity;
        }

        public IEnumerable<Contact> GetAll()
        {
            return _contactDal.GetAll();
        }

        public Contact GetById(int id)
        {
            return _contactDal.Get(c => c.ContactId == id);
        }

    }
}
