using System.Threading.Tasks;

namespace DHL.Services.Abstractions
{
    public interface IDhlFileProcessor
    {
        Task ProcessFile(string filePath);
    }
}
