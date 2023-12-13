using WebAPI.Core.Entities;

namespace WebAPI.Entities.DTO_s
{
    public class ContactDTO : IDto
    {

        public int CompanyId { get; set; }
        public int CountryId { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string CountryName { get; set; }
    }
}
