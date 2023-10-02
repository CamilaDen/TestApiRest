using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestApiRest.Attributes;

namespace TestApiRest.Domain.Entities
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdBook { get; set; }
        [StringLength(100)]
        [FirstCapitalLetter]
        public string Tittle { get; set; }
        [StringLength(50)]
        [FirstCapitalLetter]
        public string Publisher { get; set; }

    }
}
