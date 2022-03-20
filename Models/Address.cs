using System;
using System.Collections.Generic;

namespace TMSAPI.Models
{
    public partial class Address
    {
        public Address(string namePlace, string gps, string addressNumber, string district, string country, string street, string zipCode, string province)
        {
            NamePlace = namePlace;
            Gps = gps;
            AddressNumber = addressNumber;
            District = district;
            Country = country;
            Street = street;
            ZipCode = zipCode;
            Province = province;
        }

        public void Update(string namePlace, string gps, string addressNumber, string district, string country, string street, string zipCode, string province)
        {
            NamePlace = namePlace;
            Gps = gps;
            AddressNumber = addressNumber;
            District = district;
            Country = country;
            Street = street;
            ZipCode = zipCode;
            Province = province;
        }

        public int Id { get; set; }
        public string NamePlace { get; set; }
        public string Gps { get; set; }
        public string AddressNumber { get; set; }
        public string District { get; set; }
        public string Country { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string Province { get; set; }
    }
}
