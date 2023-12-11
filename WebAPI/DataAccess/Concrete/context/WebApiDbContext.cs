using Microsoft.EntityFrameworkCore;
using WebAPI.Entities.Concrete;

namespace WebAPI.DataAccess.Concrete.context
{
    public class WebApiDbContext :DbContext
    {
        public WebApiDbContext(DbContextOptions options) : base(options)
        {
        }

        public WebApiDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasKey(c => c.CompanyId);
            modelBuilder.Entity<Contact>().HasKey(c => c.ContactId);
            modelBuilder.Entity<Country>().HasKey(c => c.CountryId);

            // Relationships
            modelBuilder.Entity<Contact>()
                .HasOne(c => c.Company)
                .WithMany(c => c.Contacts)
                .HasForeignKey(c => c.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Contact>()
                .HasOne(c => c.Country)
                .WithMany(c => c.Contacts)
                .HasForeignKey(c => c.CountryId)
                .OnDelete(DeleteBehavior.Cascade);
        }





    }
}
