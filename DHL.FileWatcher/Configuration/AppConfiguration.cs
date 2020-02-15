using DHL.DHL.FileWatcher.Configuration;

namespace DHL.FileWatcher.Configuration
{
    public class AppConfiguration
    {
        public string InputPath { get; set; }

        public string OutputPath { get; set; }

        public CredentialsConfiguration CredentialsConfiguration { get; set; }
    }
}
