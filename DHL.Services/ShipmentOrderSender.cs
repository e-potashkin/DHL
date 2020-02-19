using System;
using System.Threading.Tasks;
using Autofac.Extras.DynamicProxy;
using DHL.Common.Helpers;
using DHL.Common.Utils;
using DHL.Services.Abstractions;
using DHL.Services.Models;
using RestSharp;

namespace DHL.Services
{
    [Intercept(typeof(LogInterceptor))]
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

        public byte[] DownloadFile(string request) => _dhlHttpClientFactory.DownloadFile(request);

        public async Task<IRestResponse<T>> SendAsync<T>(ShipmentOrder shipmentOrder)
        {
            var payload = _shipmentOrderFactory.CreatePayload(shipmentOrder);

            var response = await RetryingHelper
                .CreateDefaultPolicy<Exception>()
                .ExecuteWithPolicy(() => _dhlHttpClientFactory.CreateShipmentOrderRequestAsync<T>(payload)).ConfigureAwait(false);

            return response;
        }
    }
}
