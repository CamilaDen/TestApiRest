using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace TestApiRest.Domain.Entities
{
    public class DetallePedido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDetalle { get; set; }

        [ForeignKey("IdPedido")]
        public Pedido Pedido { get; set; }
        public int IdPedido { get; set; }
        [ForeignKey("Idlibro")]
        public Libro Libro { get; set; }
        public int Idlibro { get; set; }

        [Column(TypeName = "date")]
        public DateTime FechaPedido { get; set; }
    }
}
