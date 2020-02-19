using System.Threading.Tasks;
using DHL.Services.Models;
using RestSharp;

namespace DHL.Services.Abstractions
{
    public interface IShipmentOrderSender
    {
        Task<IRestResponse<T>> SendAsync<T>(ShipmentOrder shipmentOrders);
    }
}
