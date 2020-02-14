using System;
using System.IO;
using DHL.FileWatcher.Configuration;
using Microsoft.Extensions.Configuration;

namespace DHL.FileWatcher
{
    class Program
    {
        private static AppConfiguration _appConfig;

        static void Main()
        {
            BuildSettings();

            MonitorDirectory();

            Console.ReadKey();
        }

        private static void MonitorDirectory()
        {
            var fileSystemWatcher = new FileSystemWatcher
            {
                Path = _appConfig.DirectoryInputPath,
                Filter = "*.csv",
                EnableRaisingEvents = true
            };

            fileSystemWatcher.Created += FileSystemWatcher_Created;
            fileSystemWatcher.Deleted += FileSystemWatcher_Deleted;
        }

        private static void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File created: {0}", e.Name);

            //try
            //{
            //    if (File.Exists(path))
            //    {
            //        var fileStream = File.OpenRead(path);
            //        var sreamReader = new StreamReader(path);
            //    }
            //}
            //catch (IOException)
            //{
            //}
        }

        private static void FileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File deleted: {0}", e.Name);
        }

        private static void BuildSettings()
        {
            var builder = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                 .Build();

            _appConfig = builder.GetSection("Settings").Get<AppConfiguration>();
        }
    }
}
