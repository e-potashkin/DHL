using System;
using System.Net.Http;
using System.Threading.Tasks;
using DHL.Sdk.Api;
using DHL.Sdk.Handlers;
using DHL.Sdk.Models.Responses;
using Refit;

namespace DHL.Sdk
{
    public class DHLClient
    {
        private readonly IServicesApi _api;
        private readonly string _userName;
        private readonly string _userPassword;
        private const string BASE_ADDRESS = "https://api-qa.dhlecommerce.com";
        private const string SANDBOX_ADDRESS = "https://api-sandbox.dhlecommerce.com";

        public DHLClient(string userName, string userPassword)
        {
            _userName = userName ?? throw new ArgumentNullException(nameof(userName));
            _userPassword = userPassword ?? throw new ArgumentNullException(nameof(userPassword));

            _api = RestService.For<IServicesApi>(new HttpClient(new AuthenticatedHttpClientHandler(GetAccessToken)) { BaseAddress = new Uri(BASE_ADDRESS) });
        }

        public async Task<object> GetLabelAsync()
        {
            return await _api.GetLabelAsync();
        }

        private async Task<AuthResponse> GetAccessToken() => await _api.GetAccessTokenAsync(_userName, _userPassword);
    }
}