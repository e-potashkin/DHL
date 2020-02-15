using System.Threading.Tasks;
using DHL.Common.Models.Authentication;
using RestSharp;
using RestSharp.Authenticators;

namespace DHL.DHL.Services
{
    public class DhlHttpClientFactory
    {
        public async Task<IRestResponse> CreateShipmentOrderRequest(string payload, AuthConfiguration authConfig)
        {
            var client = new RestClient(authConfig.Url)
            {
                Authenticator = new HttpBasicAuthenticator(authConfig.User, authConfig.Signature)
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
