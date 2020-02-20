using System.Threading.Tasks;
using RestSharp;

namespace DHL.Services.Abstractions
{
    public interface IMgTechnoHttpClientFactory
    {
        Task<IRestResponse<T>> GetAuthenticationToken<T>();

        Task<IRestResponse<T>> GetCompanyInfo<T>(string authToken);
    }
}
