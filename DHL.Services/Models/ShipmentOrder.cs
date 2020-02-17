using CsvHelper.Configuration.Attributes;

namespace DHL.Services.Models
{
    public class ShipmentOrder
    {
        [Index(0)]
        public string A { get; set; }

        [Index(1)]
        public string B { get; set; }

        [Index(4)]
        public string E { get; set; }

        [Index(9)]
        public string J { get; set; }

        [Index(10)]
        public string K { get; set; }

        [Index(11)]
        public string L { get; set; }

        [Index(12)]
        public string M { get; set; }

        [Index(13)]
        public string N { get; set; }

        [Index(14)]
        public string O { get; set; }

        [Index(15)]
        public string P { get; set; }

        [Index(16)]
        public string Q { get; set; }

        [Index(18)]
        public string S { get; set; }

        [Index(19)]
        public string T { get; set; }

        [Index(25)]
        public string Z { get; set; }

        [Index(26)]
        public string AA { get; set; }
    }
}
