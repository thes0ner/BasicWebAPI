using WebAPI.Core.Entities;

namespace WebAPI.Entities.Concrete
{
    public class Company:IEntity
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public ICollection<Contact> Contacts { get; set; }
    }
}
