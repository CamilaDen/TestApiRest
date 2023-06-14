using TestApiRest.Domain.Entities;

namespace TestApiRest.Repository.Interfaces
{
    public interface IPedidosRepository
    {
        Task<List<Pedido>> GetAllPedidos();
        Task<Pedido> GetPedidoById(int id);
        Task<Pedido> CreatePedido(Pedido pedido);
        Task UpdatePedido(Pedido pedido);
        Task DeletePedido(int id);
        Task AddDetailPedido(int idPedido, DetallePedido detallePedido);
        
    }
}
