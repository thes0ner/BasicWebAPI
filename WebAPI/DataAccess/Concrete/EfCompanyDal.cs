using WebAPI.DataAccess.Abstract;
using WebAPI.DataAccess.Concrete.context;
using WebAPI.Entities.Concrete;
using WebAPI.Repository;

namespace WebAPI.DataAccess.Concrete
{
    public class EfCompanyDal : BaseRepository<Company>, ICompanyDal
    {
        public EfCompanyDal(WebApiDbContext dbContext) : base(dbContext)
        {
        }
    }
}
