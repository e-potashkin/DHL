using System;
using Autofac;
using DHL.Services.Abstractions;

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
