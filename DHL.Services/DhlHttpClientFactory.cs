using System.Threading.Tasks;
using DHL.Common.Models.Authentication;
using DHL.Services.Abstractions;
using DHL.Services.Models;
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

        public async Task<IRestResponse<ShipmentOrderResponse>> CreateShipmentOrderRequestAsync(string payload)
        {
            var client = new RestClient(_authConfig.Url)
            {
                Authenticator = new HttpBasicAuthenticator(_authConfig.ApiUser, _authConfig.ApiPassword)
            };

            var request = new RestRequest(Method.POST);
            request.AddHeader("SOAPAction", "urn:createShipmentOrder");
            request.AddParameter("undefined", payload, ParameterType.RequestBody);
            request.OnBeforeDeserialization = response => response.ContentType = "application/xml";

            return await client.ExecuteAsync<ShipmentOrderResponse>(request).ConfigureAwait(false);
        }
    }
}
