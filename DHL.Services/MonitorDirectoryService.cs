using System.IO;
using DHL.Common.Helpers;
using DHL.Services.Abstractions;

namespace DHL.Services
{
    public class MonitorDirectoryService : IMonitorDirectoryService
    {
        private readonly IDhlFileProcessor _dhlFileProcessor;
        private readonly string _inputPath;

        public MonitorDirectoryService(IDhlFileProcessor dhlProcessor, string inputPath)
        {
            _dhlFileProcessor = dhlProcessor;
            _inputPath = inputPath;
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
