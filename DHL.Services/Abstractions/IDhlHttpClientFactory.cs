using System.Threading.Tasks;
using RestSharp;

namespace DHL.Services.Abstractions
{
    public interface IDhlHttpClientFactory
    {
        Task<IRestResponse<T>> CreateShipmentOrderRequestAsync<T>(string payload);
    }
}
