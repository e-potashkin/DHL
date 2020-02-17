using System.Threading.Tasks;
using RestSharp;

namespace DHL.Services.Abstractions
{
    public interface IDhlHttpClientFactory
    {
        Task<IRestResponse> CreateShipmentOrderRequestAsync(string payload);
    }
}
