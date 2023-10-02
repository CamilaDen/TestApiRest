using TestApiRest.Domain.DTO_s;
using TestApiRest.DTO_s;

namespace TestApiRest.Services.Interfaces
{
    public interface IOrdersService
    {
        List<OrderDTO> GetAllOrders();
        OrderDTO GetOrderById(int id);
        OrderDTO CreateOrder(OrderDTO orderDTO);
        //PedidoDTO UpdatePedido(PedidoDTO pedidoUpdateDTO); //No deberia poderse modificar un pedido.
        OrderDTO DeleteOrder(int id);
        byte[] DownloadPDF(int orderId);
    }
}
