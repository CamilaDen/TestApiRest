using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TestApiRest.Validations;

namespace TestApiRest.Domain.Entities
{
    public class Libro
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdLibro { get; set; }
        [StringLength(100)]
        [PrimeraLetraMayus]
        public string Titulo { get; set; }
        [StringLength(50)]
        [PrimeraLetraMayus]
        public string Editorial { get; set; }

    }
}
