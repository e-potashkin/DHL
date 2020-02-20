using System.IO;
using DHL.Common.Helpers;
using DHL.Services.Abstractions;

namespace DHL.Services
{
    public class MonitorDirectoryService : IMonitorDirectoryService
    {
        private readonly string _inputPath;
        private readonly IDhlFileProcessor _dhlFileProcessor;

        public MonitorDirectoryService(string inputPath, IDhlFileProcessor dhlProcessor)
        {
            _inputPath = inputPath;
            _dhlFileProcessor = dhlProcessor;
        }

        public void StartMonitoring()
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
            AsyncHelper.RunSync(() => _dhlFileProcessor.ProcessFile(e.FullPath));
        }
    }
}
