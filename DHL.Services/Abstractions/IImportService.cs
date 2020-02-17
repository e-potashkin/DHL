using System.Threading.Tasks;

namespace DHL.Services.Abstractions
{
    public interface IImportService
    {
        /// <summary>
        /// Starts a process pipeline (import, mapping, http request, saving result).
        /// </summary>
        /// <param name="filePath"></param>
        Task ImportAndProcessCsvAsync(string filePath);
    }
}
