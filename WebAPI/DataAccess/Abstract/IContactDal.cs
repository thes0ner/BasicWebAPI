using WebAPI.Entities.Concrete;
using WebAPI.Repository;

namespace WebAPI.DataAccess.Abstract
{
    public interface IContactDal : IRepository<Contact>
    {
        //DTO
        //GetContactsWithCompanyAndCountry<DTO>();

    }
}
