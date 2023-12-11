﻿namespace WebAPI.Entities.Concrete
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string ContactName { get; set; }
        public int CompanyId { get; set; }
        public int CountryId { get; set; }
        public Company Company { get; set; }
        public Country Country { get; set; }
    }
}
