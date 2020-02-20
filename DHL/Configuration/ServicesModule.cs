using Autofac;
using DHL.Services;
using DHL.Services.Abstractions;

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
            builder.RegisterType<ShipmentOrderFactory>().As<IShipmentOrderFactory>().WithParameter("authConfig", _appConfig.AuthConfiguration);
            builder.RegisterType<DhlHttpClientFactory>().As<IDhlHttpClientFactory>().WithParameter("authConfig", _appConfig.AuthConfiguration);
            builder.RegisterType<MgTechnoHttpClientFactory>().As<IMgTechnoHttpClientFactory>().WithParameter("authConfig", _appConfig.MgTechnoAuthConfiguration);
            builder.RegisterType<MonitorDirectoryService>().As<IMonitorDirectoryService>().WithParameter("inputPath", _appConfig.InputPath);
            builder.RegisterType<FileManagerService>().As<IFileManagerService>().WithParameter("outputPath", _appConfig.OutputPath);
        }
    }
}
