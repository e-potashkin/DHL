using System.IO;
using DHL.Services.Abstractions;

namespace DHL.Services
{
    public class FileManagerService : IFileManagerService
    {
        private readonly string _outputPath;

        public FileManagerService(string outputPath)
        {
            _outputPath = outputPath;
        }

        public string Move(string filePath)
        {
            var fileName = Path.GetFileNameWithoutExtension(filePath);
            var outputDirectory = Path.Combine(_outputPath, fileName);
            var movedFilePath = Path.Combine(outputDirectory, $"{fileName}.csv");

            Directory.CreateDirectory(outputDirectory);

            if (File.Exists(movedFilePath)) File.Delete(movedFilePath);
            File.Move(filePath, movedFilePath);

            return outputDirectory;
        }

        public void SaveLabel(string labelName, string outputDirectory, byte[] fileBytes)
        {
            File.WriteAllBytes(Path.Combine(outputDirectory, $"{labelName}.pdf"), fileBytes);
        }
    }
}
