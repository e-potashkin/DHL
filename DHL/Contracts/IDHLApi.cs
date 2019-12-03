using System.Threading.Tasks;
using DHL.Models;
using Refit;

namespace DHL
{
    public interface IDHLApi
    {
        [Get("/account/v1/auth/accesstoken?client_id={username}&client_secret={password}")]
        Task<AuthResponse> GetAccessTokenAsync(string username, string password);

        [Post("")]
        [Headers("Authorization: Bearer")]
        Task<object> GetLabelAsync();
    }
}