using System;
namespace App.Models
{
    public class HotelInfo : Resource
    {
        public string Title { get; set; }
        public string Tagline { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public Address Location { get; set; }

        public class Address
        {
            public string street;
            public string city;
            public string Country;

        }
    }
}
