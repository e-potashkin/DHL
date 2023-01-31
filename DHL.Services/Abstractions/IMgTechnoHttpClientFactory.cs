using System.Threading.Tasks;
using RestSharp;

namespace DHL.Services.Abstractions
{
    public interface IMgTechnoHttpClientFactory
    {
        Task<RestResponse<T>> GetAuthenticationToken<T>();

        Task<RestResponse<T>> GetCompanyInfo<T>(string authToken);
    }
}
