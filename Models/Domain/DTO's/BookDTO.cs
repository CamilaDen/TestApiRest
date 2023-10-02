using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestApiRest.Attributes;

namespace TestApiRest.DTO_s
{
    public class BookDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdBook{ get; set; }
        [StringLength(100)]
        [FirstCapitalLetter]
        [Required]
        public string Tittle { get; set; }
        [StringLength(50)]
        [FirstCapitalLetter]
        [Required]
        public string Publisher { get; set; }
    }
}
