using DHL.Services.Models;

namespace DHL.Services.Abstractions
{
    public interface IShipmentOrderFactory
    {
        string CreatePayload(ShipmentOrder shipmentOrder);
    }
}
