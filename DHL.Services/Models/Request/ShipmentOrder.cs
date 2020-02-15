namespace DHL.Services.Models.Request
{
    public class ShipmentOrder
    {
        public string SequenceNumber { get; set; }

        public Shipment Shipment { get; set; }
    }
}
