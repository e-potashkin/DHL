using System.Threading.Tasks;
using RestSharp;

namespace DHL.DHL.Services.Abstractions
{
    public interface IDhlHttpClientFactory
    {
        Task<IRestResponse> CreateShipmentOrderRequestAsync(string payload);
    }
}
