using Autofac;
using DHL.Common;
using DHL.DHL.Common;
using DHL.DHL.Common.Utils;
using DHL.DHL.Services;
using DHL.DHL.Services.Abstractions;
using DHL.FileWatcher.Configuration;
using Microsoft.Extensions.Configuration;

namespace DHL.DHL.FileWatcher
{
    public static class Startup
    {
        public static IContainer BuildContainer()
        {
            var builder = new ConfigurationBuilder();

            return new ApplicationConfigurator<AppConfiguration>(null, (builder, appConfig) =>
            {
                builder.RegisterModule(new AutoregisterableModule("DHL"));
                builder.RegisterType<MonitorDirectoryService>().As<IMonitorDirectoryService>().WithParameter("inputPath", appConfig.InputPath);
            }, builder)
            .AddEnvironmentVariables()
            .AddJsonFile(EnvironmentConfigurator.GetEnvironmentName())
            .Configure();
        }
    }
}
