using System;
using System.Threading.Tasks;
using DHL.Common.Helpers;
using DHL.Common.Models.Authentication;
using DHL.DHL.Services;
using DHL.Services.Abstractions.Senders;
using DHL.Services.Models.Request;

namespace DHL.Services.Senders
{
    public class ShipmentOrderSender : IShipmentOrderSender
    {
        private readonly AuthConfiguration _authConfig;
        private readonly ShipmentOrderFactory _shipmentOrderFactory;
        private readonly DhlHttpClientFactory _dhlHttpClientFactory;

        public ShipmentOrderSender(AuthConfiguration authConfig)
        {
            _authConfig = authConfig;
            _shipmentOrderFactory = new ShipmentOrderFactory();
            _dhlHttpClientFactory = new DhlHttpClientFactory();
        }

        public async Task SendAsync(ShipmentOrder shipmentOrder)
        {
            var payload = _shipmentOrderFactory.CreatePayload(shipmentOrder, _authConfig);

            var response = await RetryingHelper
                .CreateDefaultPolicy<Exception>()
                .ExecuteWithPolicy(() => _dhlHttpClientFactory.CreateShipmentOrderRequest(payload, _authConfig));

            if (response.IsSuccessful)
            {
                // TODO: implement
            }
        }
    }
}
