using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TestApiRest.Validations;
using System.Text.Json.Serialization;
using TestApiRest.Domain.Entities;

namespace TestApiRest.DTO_s
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        [StringLength(50)]
        [PrimeraLetraMayus]
        public string nombre { get; set; }

        [StringLength(50)]
        [PrimeraLetraMayus]
        public string apellido { get; set; }
        public TipoDocumento tipoDocumento { get; set; }
        
        public int numeroDocumento { get; set; }

        [DataType(DataType.Date)]
        [JsonPropertyName("fechaNacimiento")]
        [JsonConverter(typeof(ConvertirFecha))]
        public DateTime fechaNacimiento { get; set; }

    }
}
