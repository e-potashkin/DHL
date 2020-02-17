using System.IO;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DHL.Common;
using DHL.Common.Utils;
using DHL.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DHL
{
    public static class Startup
    {
        public static IContainer BuildContainer()
        {
            var services = new ServiceCollection();
            var configurationBuilder = new ConfigurationBuilder();

            return new ApplicationConfigurator<AppConfiguration>(null, (builder, appConfig) =>
            {
                services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
                builder.RegisterModule(new AutoregisterableModule(typeof(Startup).Assembly.GetName().Name));
                builder.RegisterModule(new ServicesModule(appConfig));
                builder.Populate(services);
                Directory.CreateDirectory(appConfig.InputPath);
                Directory.CreateDirectory(appConfig.OutputPath);
            }, configurationBuilder)
            .AddEnvironmentVariables()
            .AddJsonFile(EnvironmentConfigurator.GetEnvironmentName())
            .Configure();
        }
    }
}
