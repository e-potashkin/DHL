using System.Threading.Tasks;
using DHL.Services.Models;
using RestSharp;

namespace DHL.Services.Abstractions
{
    public interface IShipmentOrderSender
    {
        byte[] DownloadFile(string directory);

        Task<RestResponse<T>> SendAsync<T>(ShipmentOrder shipmentOrders, MgTechnoCompanyInfo companyInfo);
    }
}
