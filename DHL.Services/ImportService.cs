using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using DHL.Common.Models.Mappers;
using DHL.Services.Abstractions;
using DHL.Services.Abstractions.Senders;

namespace DHL.Services
{
    public class ImportService : IImportService
    {
        private readonly IOrderSender _orderSender;

        public ImportService(IOrderSender orderSender)
        {
            _orderSender = orderSender;
        }

        public void ImportFromCsv(string filePath)
        {
            IReadOnlyCollection<Test> records;

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.Delimiter = "|";
                records = csv.GetRecords<Test>().ToList();
            }

            _orderSender.SendOrderToDHL();
            // TODO: Send to the SOAP service
        }
    }
}
