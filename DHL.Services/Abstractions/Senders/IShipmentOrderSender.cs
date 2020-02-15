using System.Threading.Tasks;
using DHL.Services.Models.Request;

namespace DHL.Services.Abstractions.Senders
{
    public interface IShipmentOrderSender
    {
        Task SendAsync(ShipmentOrder shipmentOrders);
    }
}
