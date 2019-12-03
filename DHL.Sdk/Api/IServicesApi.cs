using System.Threading.Tasks;
using DHL.Sdk.Models.Responses;
using Refit;

namespace DHL.Sdk.Api
{
    public interface IServicesApi
    {
        [Post("")]
        [Headers("Authorization: Bearer")]
        Task<object> GetLabelAsync();

        [Get("/account/v1/auth/accesstoken?client_id={username}&client_secret={password}")]
        Task<AuthResponse> GetAccessTokenAsync(string username, string password);
    }
}