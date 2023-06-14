using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestApiRest.Domain.Entities
{
    public class Pedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPedido { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
        public int IdUsuario { get; set; }
        public List<DetallePedido> ListaDetallePedidos { get; set; }

    }
}
