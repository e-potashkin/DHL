using CsvHelper.Configuration.Attributes;
using DHL.Common.Extensions;

namespace DHL.Services.Models
{
    public class ShipmentOrder
    {
        private string _customerReference;

        [Index(0)]
        public string CustomerReference
        {
            get { return _customerReference; }
            set { _customerReference = value.ConvertToHtmlLtGtSymbol(); }
        }

        [Index(1)]
        public string Mamdat { get; set; }

        [Index(12)]
        public string CompanyName { get; set; }

        [Index(13)]
        public string FirstName { get; set; }

        [Index(14)]
        public string LastName { get; set; }

        [Index(15)]
        public string Zip { get; set; }

        [Index(16)]
        public string City { get; set; }

        [Index(18)]
        public string StreetName { get; set; }

        [Index(19)]
        public string StreetNumber { get; set; }

        [Index(25)]
        public string Country { get; set; }

        private string _weight;

        [Index(26)]
        public string Weight
        {
            get { return _weight; }
            set { _weight = value.Replace(',', '.'); }
        }

        [Index(54)]
        public string LabelCount { get; set; }
    }
}
