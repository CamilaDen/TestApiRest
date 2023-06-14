using TestApiRest.Domain.DTO_s;
using TestApiRest.DTO_s;

namespace TestApiRest.Services.Interfaces
{
    public interface IPedidosService
    {
        Task<List<PedidoDTO>> GetAllPedidos();
        Task<PedidoDTO> GetPedidoById(int id);
        Task<int> CreatePedido(PedidoDTO pedidoCreateDTO);
        Task UpdatePedido(int id, PedidoDTO pedidoUpdateDTO);
        Task DeletePedido(int id);
        Task AddDetailPedido(int idPedido, DetallePedidoDTO detallePedidoCreateDTO);
    }
}
