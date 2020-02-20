using DHL.Common.Extensions;

namespace DHL.Services.Models
{
    public class MgTechnoCompanyInfo
    {
        private string _manufacturer;

        public int Id { get; set; }

        public string Brand { get; set; }

        public string CountryId { get; set; }

        public string FullName { get; set; }

        public string Manufacturer
        {
            get { return _manufacturer; }
            set { _manufacturer = value.ConvertAmpToHtmlSymbol(); }
        }

        public string Name { get; set; }

        public string Prefix { get; set; }

        public Address Address { get; set; }
    }

    public class Address
    {
        public string City { get; set; }

        public string Company { get; set; }

        public string Country { get; set; }

        public string Name { get; set; }

        public string Region { get; set; }

        public string Street { get; set; }

        public string ZipCode { get; set; }
    }
}
