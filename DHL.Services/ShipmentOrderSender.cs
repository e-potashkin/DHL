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
        private readonly IDhlHttpClientFactory _dhlHttpClientFactory;
        private readonly IShipmentOrderFactory _shipmentOrderFactory;

        public ShipmentOrderSender(IShipmentOrderFactory shipmentOrderFactory, IDhlHttpClientFactory dhlHttpClientFactory)
        {
            _shipmentOrderFactory = shipmentOrderFactory;
            _dhlHttpClientFactory = dhlHttpClientFactory;
        }

        public byte[] DownloadFile(string request) => _dhlHttpClientFactory.DownloadFile(request);

        public async Task<RestResponse<T>> SendAsync<T>(ShipmentOrder shipmentOrder, MgTechnoCompanyInfo companyInfo)
        {
            var payload = _shipmentOrderFactory.CreatePayload(shipmentOrder, companyInfo);

            return await RetryingHelper
                .CreateDefaultPolicy<Exception>()
                .ExecuteWithPolicy(() => _dhlHttpClientFactory
                .CreateShipmentOrderRequestAsync<T>(payload))
                .ConfigureAwait(false);
        }
    }
}
