using System.Threading.Tasks;
using DHL.Services.Models;
using RestSharp;

namespace DHL.Services.Abstractions
{
    public interface IDhlHttpClientFactory
    {
        Task<IRestResponse<ShipmentOrderResponse>> CreateShipmentOrderRequestAsync(string payload);
    }
}
