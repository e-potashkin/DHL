using System.Threading.Tasks;
using DHL.Services.Abstractions;
using DHL.Services.Models;
using Serilog;

namespace DHL.Services
{
    public class DhlFileProcessor : IDhlFileProcessor
    {
        private readonly ICompanyService _companyService;
        private readonly IFileManagerService _fileManagerService;
        private readonly IImportService _importService;
        private readonly IShipmentOrderSender _shipmentOrderSender;

        public DhlFileProcessor(ICompanyService companyService,
            IImportService importService,
            IFileManagerService fileManagerService,
            IShipmentOrderSender shipmentOrderSender)
        {
            _companyService = companyService;
            _importService = importService;
            _fileManagerService = fileManagerService;
            _shipmentOrderSender = shipmentOrderSender;
        }

        public async Task ProcessFile(string filePath)
        {
            var orders = _importService.ImportCsv<ShipmentOrder>(filePath);
            var outputDirectory = _fileManagerService.Move(filePath);
            var companyInfo = await _companyService.GetCompanyInfo().ConfigureAwait(false);

            foreach (var order in orders)
            {
                Log.Information("Request to the DHL started.");
                var response = await _shipmentOrderSender.SendAsync<ShipmentOrderResponse>(order, companyInfo).ConfigureAwait(false);

                if (response.IsSuccessful)
                {
                    var labelUrl = response.Data.GetLabelUrl();
                    if (!string.IsNullOrEmpty(labelUrl))
                    {
                        Log.Information($"Request successful. LabelUrl: {labelUrl}");
                        var fileBytes = _shipmentOrderSender.DownloadFile(labelUrl);
                        _fileManagerService.SaveLabel(order.CustomerReference, outputDirectory, fileBytes);
                    }
                    else
                    {
                        Log.Warning("LabelUrl is empty.");
                    }
                }
                else
                {
                    Log.Warning($"Request to the DHL has been failed. ErrorMessage: {response.ErrorMessage}");
                }
            }
        }
    }
}
