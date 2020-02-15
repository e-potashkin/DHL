using System;
using System.Collections.Generic;
using Autofac;
using Microsoft.Extensions.Configuration;

namespace DHL.Common
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

        public ApplicationConfigurator<T> AddDefaultConfiguration(IReadOnlyDictionary<string, string> defaultConfiguration)
        {
            _configurationBuilder.AddInMemoryCollection(defaultConfiguration);
            return this;
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
            _customContainerBuilder?.Invoke(_builder, appConfiguration);

            return _builder.Build();
        }
    }
}
