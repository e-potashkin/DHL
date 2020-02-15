using Autofac;
using DHL.Services;
using DHL.Services.Abstractions;
using DHL.Services.Abstractions.Senders;
using DHL.Services.Senders;

namespace DHL.Configuration
{
    public class ServicesModule : Module
    {
        private readonly AppConfiguration _appConfig;

        public ServicesModule(AppConfiguration appConfig)
        {
            _appConfig = appConfig;
        }

        /// <summary>
        /// Registers dependencies
        /// </summary>
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MonitorDirectoryService>().As<IMonitorDirectoryService>().WithParameter("inputPath", _appConfig.InputPath);
            builder.RegisterType<OrderSender>().As<IOrderSender>().WithParameter("authConfig", _appConfig.AuthConfiguration);
        }
    }
}
