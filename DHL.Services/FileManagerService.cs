using System.IO;
using Autofac.Extras.DynamicProxy;
using DHL.Common.Extensions;
using DHL.Common.Utils;
using DHL.Services.Abstractions;
using Serilog;

namespace DHL.Services
{
    [Intercept(typeof(LogInterceptor))]
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
            Log.Information($"Directory has been created. Path: {outputDirectory}");

            if (File.Exists(movedFilePath)) File.Delete(movedFilePath);
            File.Move(filePath, movedFilePath);
            Log.Information($"FIle {fileName} has been moved to the {outputDirectory}");

            return outputDirectory;
        }

        public void SaveLabel(string labelName, string outputDirectory, byte[] fileBytes)
        {
            var fileName = $"{labelName.RemoveLtGtSymbol()}.pdf";

            File.WriteAllBytes(Path.Combine(outputDirectory, fileName), fileBytes);
            Log.Information($"Label {fileName} has been saved to the: {outputDirectory}");
        }
    }
}
