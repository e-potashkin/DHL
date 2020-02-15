using System;
using System.IO;
using DHL.DHL.Services.Abstractions;

namespace DHL.DHL.Services
{
    public class MonitorDirectoryService : IMonitorDirectoryService
    {
        private readonly string _inputPath;

        public MonitorDirectoryService(string inputPath)
        {
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

        private static void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File created: {0}", e.Name);
        }
    }
}
