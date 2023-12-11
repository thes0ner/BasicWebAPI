using WebAPI.DataAccess.Abstract;
using WebAPI.DataAccess.Concrete.context;
using WebAPI.Entities.Concrete;
using WebAPI.Repository;

namespace WebAPI.DataAccess.Concrete
{
    public class EfCountryDal : BaseRepository<Country>, ICountryDal
    {
        public EfCountryDal(WebApiDbContext dbContext) : base(dbContext)
        {
        }
    }
}
