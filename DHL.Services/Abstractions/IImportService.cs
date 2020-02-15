using System.Threading.Tasks;

namespace DHL.Services.Abstractions
{
    public interface IImportService
    {
        Task ImportCsvAsync(string filePath);
    }
}
