using DHL.Common.Models.Authentication;

namespace DHL.FileWatcher.Configuration
{
    public class AppConfiguration
    {
        public string InputPath { get; set; }

        public string OutputPath { get; set; }

        public AuthConfiguration AuthConfiguration { get; set; }
    }
}
