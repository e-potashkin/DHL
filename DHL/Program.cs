using System;
using Autofac;
using DHL.Services.Abstractions;

namespace DHL
{
    internal static class Program
    {
        private static void Main()
        {
            var container = Startup.BuildContainer();
            var mds = container.Resolve<IMonitorDirectoryService>();

            mds.StartMonitoring();

            Console.Read();
        }
    }
}
