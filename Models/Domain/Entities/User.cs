using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestApiRest.Attributes;

namespace TestApiRest.Domain.Entities
{
    public enum TypeOfDocument { DNI, LE, LC }
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUser { get; set; }
        [StringLength(50)]
        [Required]
        [FirstCapitalLetter]
        public string Name { get; set; }
        [StringLength(50)]
        [Required]
        [FirstCapitalLetter]
        public string Surname { get; set; }
        [StringLength(30)]
        public TypeOfDocument TypeOfDocument { get; set; }
        public int DocumentNumber { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

    }
}
