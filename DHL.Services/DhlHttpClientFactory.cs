using System.Threading.Tasks;
using DHL.Common.Models.Authentication;
using DHL.DHL.Services.Abstractions;
using RestSharp;
using RestSharp.Authenticators;

namespace DHL.DHL.Services
{
    public class DhlHttpClientFactory : IDhlHttpClientFactory
    {
        private readonly AuthConfiguration _authConfig;

        public DhlHttpClientFactory(AuthConfiguration authConfig)
        {
            _authConfig = authConfig;
        }

        public async Task<IRestResponse> CreateShipmentOrderRequestAsync(string payload)
        {
            var client = new RestClient(_authConfig.Url)
            {
                Authenticator = new HttpBasicAuthenticator(_authConfig.User, _authConfig.Signature)
            }; //    "Base64Token": "c21hcnQ6cnVCQTc3IS4="
            var request = new RestRequest(Method.POST);
            // request.AddHeader("Authorization", $"Basic {_authConfig.Base64Token}");
            request.AddHeader("SOAPAction", "urn:createShipmentOrder");
            request.AddParameter("undefined", payload, ParameterType.RequestBody);
            request.OnBeforeDeserialization = resp => resp.ContentType = "application/xml";

            return await client.ExecuteAsync(request);
        }
    }
}
