using WebAPI.Core.Repository;
using WebAPI.DataAccess.Abstract;
using WebAPI.DataAccess.Concrete.context;
using WebAPI.Entities.Concrete;

namespace WebAPI.DataAccess.Concrete
{
    public class EfCompanyDal : BaseRepository<Company,WebApiDbContext>, ICompanyDal
    {
    }
}
