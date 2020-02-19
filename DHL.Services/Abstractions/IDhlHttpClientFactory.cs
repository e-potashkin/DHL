using System.Threading.Tasks;
using RestSharp;

namespace DHL.Services.Abstractions
{
    public interface IDhlHttpClientFactory
    {
        byte[] DownloadFile(string request);

        Task<IRestResponse<T>> CreateShipmentOrderRequestAsync<T>(string payload);
    }
}
