namespace DHL.Models.Request
{
    public class Address
    {
        public string StreetName { get; set; }

        public string StreetNumber { get; set; }

        public string ZIP { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public Address(string streetName,
                       string streetNumber,
                       string zip,
                       string city,
                       string country)
        {
            StreetName = streetName;
            StreetNumber = streetNumber;
            ZIP = zip;
            City = city;
            Country = country;
        }
    }
}
