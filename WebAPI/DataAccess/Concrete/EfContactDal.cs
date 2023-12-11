using WebAPI.DataAccess.Abstract;
using WebAPI.DataAccess.Concrete.context;
using WebAPI.Entities.Concrete;
using WebAPI.Repository;

namespace WebAPI.DataAccess.Concrete
{
    public class EfContactDal : BaseRepository<Contact>, IContactDal
    {
        public EfContactDal(WebApiDbContext dbContext) : base(dbContext)
        {
        }
    }
}
