using System;
using Autofac;
using Destructurama;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Exceptions;

namespace DHL.Common.Utils
{
    public class ApplicationConfigurator<T> where T : class, new()
    {
        private readonly ContainerBuilder _builder;
        private readonly ConfigurationBuilder _configurationBuilder;
        private readonly Action<IConfiguration, T> _customConfigAction;
        private readonly Action<ContainerBuilder, T> _customContainerBuilder;

        public ApplicationConfigurator(Action<IConfiguration, T> customConfigAction, Action<ContainerBuilder, T> customContainerBuilder, ConfigurationBuilder configurationBuilder)
        {
            _builder = new ContainerBuilder();
            _configurationBuilder = configurationBuilder;
            _customConfigAction = customConfigAction;
            _customContainerBuilder = customContainerBuilder;
        }

        public ApplicationConfigurator<T> AddEnvironmentVariables()
        {
            _configurationBuilder.AddEnvironmentVariables();
            return this;
        }

        public ApplicationConfigurator<T> AddJsonFile(string environment)
        {
            _configurationBuilder.AddJsonFile("appsettings.json", true);
            _configurationBuilder.AddJsonFile($"appsettings.{environment}.json", true, true);
            return this;
        }

        public IContainer Configure()
        {
            IConfiguration configuration = _configurationBuilder.Build();
            _builder.RegisterInstance(configuration).As<IConfiguration>();

            var appConfiguration = new T();
            configuration.Bind(appConfiguration);
            appConfiguration = configuration.Get<T>();
            _builder.RegisterInstance(appConfiguration).As<T>();

            _customConfigAction?.Invoke(configuration, appConfiguration);

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration).Enrich.WithExceptionDetails().Enrich.FromLogContext()
                .Destructure.UsingAttributes()
                .WriteTo.File("logs\\dhl.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            _builder.Register(_ => Log.Logger).AsImplementedInterfaces().SingleInstance();

            _customContainerBuilder?.Invoke(_builder, appConfiguration);

            LogEnvironment(appConfiguration);

            return _builder.Build();
        }

        protected virtual void LogEnvironment(T appConfiguration)
        {
            Log.Logger.Information($"Starting ENV {EnvironmentConfigurator.GetEnvironmentName()}");
        }
    }
}
