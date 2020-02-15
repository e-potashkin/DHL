using System;
using System.Threading.Tasks;
using DHL.Common.Contracts;
using DHL.Common.Models.Authentication;
using DHL.Services.Abstractions.Senders;
using RestSharp;

namespace DHL.Services.Senders
{
    public class OrderSender : IOrderSender
    {
        private readonly AuthConfiguration _authConfig;

        public OrderSender(AuthConfiguration authConfig)
        {
            _authConfig = authConfig;
        }

        public async Task SendOrderToDHL()
        {
            var result = await RetryingHelper
                .CreateDefaultPolicy<Exception>()
                .ExecuteWithPolicy(() => SendRequest(_authConfig.Url, string.Empty));

            if (result.IsSuccessful)
            {
                // TODO: implement
            }
        }

        public async Task<IRestResponse> SendRequest(string baseUrl, string soapRequest)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", $"Basic {_authConfig.Base64Token}");
            request.AddHeader("SOAPAction", "urn:createShipmentOrder");
            request.OnBeforeDeserialization = resp => resp.ContentType = "application/xml";
            request.AddParameter("undefined", soapRequest, ParameterType.RequestBody);

            return await client.ExecuteAsync(request);
        }
    }
}
