﻿namespace WebAPI.Entities.Concrete
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public ICollection<Contact> Contacts { get; set; }
    }
}