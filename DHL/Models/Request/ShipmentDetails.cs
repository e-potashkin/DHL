using System.Collections.Generic;

namespace DHL.Models.Request
{
    public class ShipmentDetails
    {
        public string Product { get; set; }
        public string AccountNumber { get; set; }
        public string CustomerReference { get; set; }
        public string ShipmentDate { get; set; }
        public string WeightInKG { get; set; }
        public IEnumerable<Notification> Notifications { get; set; }
    }
}
