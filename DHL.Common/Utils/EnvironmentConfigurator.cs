using System;

namespace DHL.Common.Utils
{
    /// <summary>
    /// Configurator used for operations with current System.Environment.
    /// </summary>
    public static class EnvironmentConfigurator
    {
        private const string Development = "Development";

        private const string Production = "Production";

        /// <summary>
        /// Retrieves the name of the current Environment.
        /// </summary>
        public static string GetEnvironmentName()
        {
            var val = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (string.IsNullOrEmpty(val))
            {
#if !DEBUG
                return Production;
#else
                return Development;
#endif
            }

            return val;
        }
    }
}
