using System.Threading.Tasks;
using DHL.Services.Models;
using RestSharp;

namespace DHL.Services.Abstractions
{
    public interface IShipmentOrderSender
    {
        Task<IRestResponse<ShipmentOrderResponse>> SendAsync(ShipmentOrder shipmentOrders);
    }
}
