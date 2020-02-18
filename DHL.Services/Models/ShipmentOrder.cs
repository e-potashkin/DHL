using CsvHelper.Configuration.Attributes;

namespace DHL.Services.Models
{
    public class ShipmentOrder
    {
        [Index(0)]
        public string CustomerReference { get; set; }

        [Index(1)]
        public string Mamdat { get; set; }

        [Index(12)]
        public string CompanyName { get; set; }

        [Index(13)]
        public string FirstName { get; set; }

        [Index(14)]
        public string LastName { get; set; }

        [Index(15)]
        public string ZIP { get; set; }

        [Index(16)]
        public string City { get; set; }

        [Index(18)]
        public string StreetName { get; set; }

        [Index(19)]
        public string StreetNumber { get; set; }

        [Index(25)]
        public string Country { get; set; }

        [Index(26)]
        public string Weight { get; set; }

        [Index(54)]
        public string LabelCount { get; set; }
    }
}
