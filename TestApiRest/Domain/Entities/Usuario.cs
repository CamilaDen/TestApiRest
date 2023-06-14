using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TestApiRest.Validations;

namespace TestApiRest.Domain.Entities
{
    public enum TipoDocumento { DNI, LE, LC }
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }
        [StringLength(50)]
        [Required]
        [PrimeraLetraMayus]
        public string Nombre { get; set; }
        [StringLength(50)]
        [Required]
        [PrimeraLetraMayus]
        public string Apellido { get; set; }
        [StringLength(30)]
        public TipoDocumento TipoDocumento { get; set; }
        public int NumeroDocumento { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaNacimiento { get; set; }

    }
}
