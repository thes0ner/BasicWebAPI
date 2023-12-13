using WebAPI.Core.Repository;
using WebAPI.DataAccess.Abstract;
using WebAPI.DataAccess.Concrete.context;
using WebAPI.Entities.Concrete;

namespace WebAPI.DataAccess.Concrete
{
    public class EfCountryDal : BaseRepository<Country, WebApiDbContext>, ICountryDal
    {

    }
}
