using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Autofac.Extras.DynamicProxy;
using CsvHelper;
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

            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.Delimiter = "|";
                csv.Configuration.HasHeaderRecord = false;
                csv.Configuration.MissingFieldFound = null;
                csv.Configuration.IgnoreBlankLines = true;

                orders = csv.GetRecords<T>().ToList();
            }

            return orders;
        }
    }
}
