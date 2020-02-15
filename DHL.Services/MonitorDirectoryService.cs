using System.IO;
using DHL.Services.Abstractions;

namespace DHL.Services
{
    public class MonitorDirectoryService : IMonitorDirectoryService
    {
        private readonly IImportService _importService;
        private readonly string _inputPath;

        public MonitorDirectoryService(IImportService importService, string inputPath)
        {
            _importService = importService;
            _inputPath = inputPath;
        }

        public void RunWatcher()
        {
            var fileSystemWatcher = new FileSystemWatcher
            {
                Path = _inputPath,
                Filter = "*.csv",
                EnableRaisingEvents = true
            };

            fileSystemWatcher.Created += FileSystemWatcher_Created;
        }

        private void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            _importService.ImportFromCsv(e.FullPath);
        }
    }
}
