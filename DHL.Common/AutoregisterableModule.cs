using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Microsoft.Extensions.DependencyModel;

namespace DHL.Common
{
    /// <summary>
    /// TopUp container components registry
    /// </summary>
    public class AutoregisterableModule : Autofac.Module
    {
        private readonly string _nameFilter;

        /// <summary>
        /// Default ctor
        /// </summary>
        /// <param name="nameFilter">Load will only search assemblies with names that contains filter</param>
        public AutoregisterableModule(string nameFilter)
        {
            _nameFilter = nameFilter;
        }

        /// <summary>
        /// Register's dependencies
        /// </summary>
        protected override void Load(ContainerBuilder builder)
        {
            var assemblies = new List<Assembly>();
            var dependencies = DependencyContext.Default.RuntimeLibraries.Where(x => x.Name.Contains(_nameFilter));
            foreach (var library in dependencies)
            {
                var assembly = Assembly.Load(new AssemblyName(library.Name));
                assemblies.Add(assembly);
            }

            var isProd = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Production";

            var containerBuilder = builder.RegisterAssemblyTypes(assemblies.ToArray()).AsImplementedInterfaces();
            if (!isProd)
            {
                containerBuilder.EnableInterfaceInterceptors();
            }

            base.Load(builder);
        }
    }
}
