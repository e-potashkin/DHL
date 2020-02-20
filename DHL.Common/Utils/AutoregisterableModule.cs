using System;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Microsoft.Extensions.DependencyModel;
using Module = Autofac.Module;

namespace DHL.Common.Utils
{
    /// <summary>
    ///     TopUp container components registry
    /// </summary>
    public class AutoregisterableModule : Module
    {
        private readonly string _nameFilter;

        /// <summary>
        ///     Default ctor
        /// </summary>
        /// <param name="nameFilter">Load will only search assemblies with names that contains filter</param>
        public AutoregisterableModule(string nameFilter)
        {
            _nameFilter = nameFilter;
        }

        /// <summary>
        ///     Register's dependencies
        /// </summary>
        protected override void Load(ContainerBuilder builder)
        {
            var dependencies = DependencyContext.Default.RuntimeLibraries.Where(x => x.Name.Contains(_nameFilter));

            builder.Register(_ => new LogInterceptor()).InstancePerLifetimeScope();

            var isProd = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production";

            var containerBuilder = builder.RegisterAssemblyTypes(dependencies.Select(library => Assembly.Load(new AssemblyName(library.Name))).ToArray())
                .AsImplementedInterfaces();
            if (!isProd) containerBuilder.EnableInterfaceInterceptors();

            base.Load(builder);
        }
    }
}
