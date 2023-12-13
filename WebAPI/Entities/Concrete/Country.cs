using WebAPI.Core.Entities;

namespace WebAPI.Entities.Concrete
{
    public class Country : IEntity
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public ICollection<Contact> Contacts { get; set; }
    }
}
