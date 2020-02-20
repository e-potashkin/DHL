using System.Threading.Tasks;
using DHL.Common.Models.Authentication;
using DHL.Services.Abstractions;
using RestSharp;
using RestSharp.Authenticators;

namespace DHL.Services
{
    public class DhlHttpClientFactory : IDhlHttpClientFactory
    {
        private readonly AuthConfiguration _authConfig;

        public DhlHttpClientFactory(AuthConfiguration authConfig)
        {
            _authConfig = authConfig;
        }

        public byte[] DownloadFile(string request)
        {
            var restClient = new RestClient(request);

            return restClient.DownloadData(new RestRequest("#", Method.GET));
        }

        public async Task<IRestResponse<T>> CreateShipmentOrderRequestAsync<T>(string payload)
        {
            var restClient = new RestClient(_authConfig.Url)
            {
                Authenticator = new HttpBasicAuthenticator(_authConfig.ApiUser, _authConfig.ApiPassword)
            };

            var request = new RestRequest(Method.POST);
            request.AddHeader("SOAPAction", "urn:createShipmentOrder");
            request.AddParameter("undefined", payload, ParameterType.RequestBody);
            request.OnBeforeDeserialization = response => response.ContentType = "application/xml";

            return await restClient.ExecuteAsync<T>(request).ConfigureAwait(false);
        }
    }
}
