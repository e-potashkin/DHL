using System.Threading.Tasks;
using DHL.Common.Models.Authentication;
using DHL.Services.Abstractions;
using RestSharp;

namespace DHL.Services
{
    public class MgTechnoHttpClientFactory : IMgTechnoHttpClientFactory
    {
        private readonly MgTechnoAuthConfiguration _authConfig;

        public MgTechnoHttpClientFactory(MgTechnoAuthConfiguration authConfig)
        {
            _authConfig = authConfig;
        }

        public async Task<IRestResponse<T>> GetAuthenticationToken<T>()
        {
            var restClient = new RestClient(_authConfig.AuthUrl)
            {
                Timeout = -1
            };

            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(_authConfig);
            request.OnBeforeDeserialization = response => response.ContentType = "application/json";

            return await restClient.ExecuteAsync<T>(request).ConfigureAwait(false);
        }

        public async Task<IRestResponse<T>> GetCompanyInfo<T>(string authToken)
        {
            var restClient = new RestClient(_authConfig.CompanyUrl)
            {
                Timeout = -1
            };

            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", $"Bearer {authToken}");
            request.OnBeforeDeserialization = response => response.ContentType = "application/json";

            return await restClient.ExecuteAsync<T>(request).ConfigureAwait(false);
        }
    }
}
