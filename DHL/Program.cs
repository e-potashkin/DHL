using System;
using System.Net.Http;
using System.Threading.Tasks;
using DHL.Handlers;
using DHL.Models;
using Refit;

namespace DHL
{
    class Program
    {
        //private static IDHLApi _api;
        private const string USER_NAME = "smart";
        private const string USER_PASSWORD = "/2F0WPhur!";
        private const string BASE_ADDRESS = "https://api-qa.dhlecommerce.com";
        private const string SANDBOX_ADDRESS = "https://api-sandbox.dhlecommerce.com";

        static async Task Main(string[] args)
        {
            var dhlClient = new DHLRestClient(USER_NAME, USER_PASSWORD, BASE_ADDRESS);
            var label = await dhlClient.Api.GetLabelAsync();

            Console.ReadLine();
        }
    }
}