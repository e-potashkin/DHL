using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using DHL.Services.Abstractions;
using DHL.Services.Models.Request;
using DHL.Services.Senders;

namespace DHL.Services
{
    public class ImportService : IImportService
    {
        private readonly IShipmentOrderSender _shipmentOrderSender;

        public ImportService(IShipmentOrderSender shipmentOrderSender)
        {
            _shipmentOrderSender = shipmentOrderSender;
        }

        public async Task ImportAndProcessCsvAsync(string filePath)
        {
            IEnumerable<ShipmentOrder> orders;

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.Delimiter = "|";
                csv.Configuration.HasHeaderRecord = false;

                orders = csv.GetRecords<ShipmentOrder>().ToList();
            }

            foreach (var order in orders)
            {
                await _shipmentOrderSender.SendAsync(order);
            }
        }
    }
}
