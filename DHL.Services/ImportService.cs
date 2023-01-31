using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Autofac.Extras.DynamicProxy;
using CsvHelper;
using CsvHelper.Configuration;
using DHL.Common.Utils;
using DHL.Services.Abstractions;

namespace DHL.Services
{
    [Intercept(typeof(LogInterceptor))]
    public class ImportService : IImportService
    {
        public IReadOnlyCollection<T> ImportCsv<T>(string filePath)
        {
            IReadOnlyCollection<T> orders;
            
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = "|",
                HasHeaderRecord = false,
                MissingFieldFound = null,
                IgnoreBlankLines = true,
            };

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, config))
            {
                orders = csv.GetRecords<T>().ToList();
            }

            return orders;
        }
    }
}
