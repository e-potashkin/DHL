using System;
using System.Threading.Tasks;
using DHL.Common.Helpers;
using DHL.Services.Abstractions;
using DHL.Services.Models;
using RestSharp;

namespace DHL.Services
{
    public class ShipmentOrderSender : IShipmentOrderSender
    {
        private readonly IShipmentOrderFactory _shipmentOrderFactory;
        private readonly IDhlHttpClientFactory _dhlHttpClientFactory;

        public ShipmentOrderSender(IShipmentOrderFactory shipmentOrderFactory,
                                   IDhlHttpClientFactory dhlHttpClientFactory)
        {
            _shipmentOrderFactory = shipmentOrderFactory;
            _dhlHttpClientFactory = dhlHttpClientFactory;
        }

        public async Task<IRestResponse> SendAsync(ShipmentOrder shipmentOrder)
        {
            var payload = _shipmentOrderFactory.CreatePayload(shipmentOrder);

            var response = await RetryingHelper
                .CreateDefaultPolicy<Exception>()
                .ExecuteWithPolicy(() => _dhlHttpClientFactory.CreateShipmentOrderRequestAsync(payload));

            return response;
        }
    }
}
