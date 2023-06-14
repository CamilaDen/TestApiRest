using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using TestApiRest.Domain.DTO_s;
using TestApiRest.Domain.Entities;

namespace TestApiRest.DTO_s
{
    public class DetallePedidoDTO
    {
        public int idDetalle { get; set; }
        public int idPedido  { get; set; }
        public LibroDTO libroDTO { get; set; }

        [Column(TypeName = "date")]
        public DateTime fechaPedido { get; set; }
    }
}
