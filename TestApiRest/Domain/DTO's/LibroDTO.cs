using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestApiRest.Validations;

namespace TestApiRest.DTO_s
{
    public class LibroDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLibro { get; set; }
        [StringLength(100)]
        [PrimeraLetraMayus]
        public string titulo { get; set; }
        [StringLength(50)]
        [PrimeraLetraMayus]
        public string editorial { get; set; }
    }
}
