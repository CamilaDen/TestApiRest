using TestApiRest.Domain.DTO_s;
using TestApiRest.DTO_s;

namespace TestApiRest.Repository.Interfaces
{
    public interface IOrdersRepository
    {
        Task<List<OrderDTO>> GetAllOrders();
        Task<OrderDTO> GetOrderById(int id);
        Task<OrderDTO> CreateOrder(OrderDTO orderDTO);
        Task<OrderDTO> DeleteOrder(int id);
        Task<byte[]> DownloadPDF(int orderId);
    }
}
