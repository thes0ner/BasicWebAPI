using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace WebAPI.DataAccess.Concrete.context
{
    public class WebApiDbContextDesignTimeFactory : IDesignTimeDbContextFactory<WebApiDbContext>
    {
        public WebApiDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder contextOptionsBuilder = new DbContextOptionsBuilder();
            contextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);

            return new(contextOptionsBuilder.Options);
        }
    }
}
