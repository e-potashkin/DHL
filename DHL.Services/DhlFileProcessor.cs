using System.Threading.Tasks;
using DHL.Services.Abstractions;
using DHL.Services.Models;

namespace DHL.Services
{
    public class DhlFileProcessor : IDhlFileProcessor
    {
        private readonly IImportService _importService;
        private readonly IShipmentOrderSender _shipmentOrderSender;

        public DhlFileProcessor(IImportService importService, IShipmentOrderSender shipmentOrderSender)
        {
            _importService = importService;
            _shipmentOrderSender = shipmentOrderSender;
        }

        public async Task ProcessFile(string filePath)
        {
            var orders = _importService.ImportCsv<ShipmentOrder>(filePath);

            foreach (var order in orders)
            {
                var response = await _shipmentOrderSender.SendAsync<ShipmentOrderResponse>(order).ConfigureAwait(false);

                if (response.IsSuccessful)
                {
                    var labelUrl = response.Data.GetLabelUrl();
                }
            }
        }
    }
}
