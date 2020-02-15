namespace DHL.Services.Models.Request
{
    public class Shipment
    {
        public Shipper Shipper { get; set; }

        public Receiver Receiver { get; set; }

        public ShipmentDetails ShipmentDetails { get; set; }
    }
}
