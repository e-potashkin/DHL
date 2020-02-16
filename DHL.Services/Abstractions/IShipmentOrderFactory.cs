using DHL.Services.Models.Request;

namespace DHL.DHL.Services.Abstractions
{
    public interface IShipmentOrderFactory
    {
        string CreatePayload(ShipmentOrder shipmentOrder);
    }
}
