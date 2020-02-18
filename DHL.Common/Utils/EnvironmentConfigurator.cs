using System;

namespace DHL.Common.Utils
{
    /// <summary>
    /// Configurator used for operations with current System.Environment.
    /// </summary>
    public static class EnvironmentConfigurator
    {
        private const string Development = "Development";

        /// <summary>
        /// Retrieves the name of the current Environment.
        /// </summary>
        public static string GetEnvironmentName()
        {
            var val = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            return string.IsNullOrEmpty(val) ? Development : val;
        }
    }
}
