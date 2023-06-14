using TestApiRest.Domain.Entities;
using TestApiRest.DTO_s;

namespace TestApiRest.Domain.DTO_s
{
    public class PedidoDTO
    {
        public int IdPedido { get; set; }
        public int IdUsuario { get; set; }
        public List<DetallePedidoDTO> ListaDetallePedidos { get; set; }
    }
}
