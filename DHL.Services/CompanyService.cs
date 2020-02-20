using System.Threading.Tasks;
using Autofac.Extras.DynamicProxy;
using DHL.Common.Helpers;
using DHL.Common.Utils;
using DHL.Services.Abstractions;
using DHL.Services.Models;

namespace DHL.Services
{
    [Intercept(typeof(LogInterceptor))]
    public class CompanyService : ICompanyService
    {
        private readonly string _authToken;

        private readonly IMgTechnoHttpClientFactory _mgTechnoHttpClientFactory;

        public CompanyService(IMgTechnoHttpClientFactory mgTechnoHttpClientFactory)
        {
            _mgTechnoHttpClientFactory = mgTechnoHttpClientFactory;
            _authToken = GetAuthToken();
        }

        public async Task<MgTechnoCompanyInfo> GetCompanyInfo()
        {
            var response = await _mgTechnoHttpClientFactory.GetCompanyInfo<MgTechnoCompanyInfo>(_authToken).ConfigureAwait(false);

            return response.Data;
        }

        private string GetAuthToken()
        {
            if (string.IsNullOrEmpty(_authToken))
            {
                return AsyncHelper.RunSync(() => _mgTechnoHttpClientFactory.GetAuthenticationToken<MgTechnoAuthResponse>()).Data.AuthenticationToken;
            }

            return _authToken;
        }
    }
}
