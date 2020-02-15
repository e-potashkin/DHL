using System.Threading.Tasks;

namespace DHL.Services.Abstractions.Senders
{
    public interface IOrderSender
    {
        Task SendOrderToDHL();
    }
}
