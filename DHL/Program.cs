using System;
using System.Threading.Tasks;
using DHL.Sdk;

namespace DHL
{
    class Program
    {
        private const string USER_NAME = "smart";
        private const string USER_PASSWORD = "/2F0WPhur!";

        static async Task Main(string[] args)
        {
            var dhlClient = new DHLClient(USER_NAME, USER_PASSWORD);
            var label = await dhlClient.GetLabelAsync();

            Console.ReadLine();
        }
    }
}