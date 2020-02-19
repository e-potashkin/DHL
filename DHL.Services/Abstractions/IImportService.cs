using System.Collections.Generic;

namespace DHL.Services.Abstractions
{
    public interface IImportService
    {
        IReadOnlyCollection<T> ImportCsv<T>(string filePath);
    }
}
