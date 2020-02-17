using DHL.Services.Models.Request;

namespace DHL.Services.Abstractions
{
    public interface IShipmentOrderFactory
    {
        string CreatePayload(ShipmentOrder shipmentOrder);
    }
}
