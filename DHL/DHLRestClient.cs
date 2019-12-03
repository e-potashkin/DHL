using DHL.Handlers;
using DHL.Models;
using Refit;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DHL
{
    public class DHLRestClient
    {
        public IDHLApi Api { get; }
        private readonly string _userName;
        private readonly string _userPassword;

        public DHLRestClient(string userName, string userPassword, string baseUri)
        {
            if (userName == null)
            {
                throw new ArgumentNullException(nameof(userName));
            }

            if (userPassword == null)
            {
                throw new ArgumentNullException(nameof(userPassword));
            }
            if (baseUri == null)
            {
                throw new ArgumentNullException(nameof(baseUri));
            }

            _userName = userName;
            _userPassword = userPassword;
            Api = RestService.For<IDHLApi>(new HttpClient(new AuthenticatedHttpClientHandler(GetAccessToken)) { BaseAddress = new Uri(baseUri) });
        }

        private async Task<AuthResponse> GetAccessToken() => await Api.GetAccessTokenAsync(_userName, _userPassword);
    }
}
