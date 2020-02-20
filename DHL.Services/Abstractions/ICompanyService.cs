using System.Threading.Tasks;
using DHL.Services.Models;

namespace DHL.Services.Abstractions
{
    public interface ICompanyService
    {
        Task<MgTechnoCompanyInfo> GetCompanyInfo();
    }
}
