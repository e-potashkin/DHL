using System;
using Autofac;
using DHL.DHL.FileWatcher;
using DHL.DHL.Services.Abstractions;

namespace DHL.FileWatcher
{
    class Program
    {
        static void Main()
        {
            var container = Startup.BuildContainer();
            var monitorService = container.Resolve<IMonitorDirectoryService>();

            monitorService.RunWatcher();

            Console.Read();
        }
    }
}
// TODO: ProcessFIle(string fileContent)
