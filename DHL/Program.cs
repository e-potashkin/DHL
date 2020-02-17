using System;
using Autofac;
using DHL.Services.Abstractions;

namespace DHL
{
    class Program
    {
        static void Main()
        {
            var container = Startup.BuildContainer();
            var monitorService = container.Resolve<IMonitorDirectoryService>();

            monitorService.StartMonitoring();

            Console.Read();
        }
    }
}
