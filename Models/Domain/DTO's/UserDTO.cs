using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TestApiRest.Attributes;
using TestApiRest.Domain.Entities;

namespace TestApiRest.DTO_s
{
    public class UserDTO
    {
        public int IdUser { get; set; }
        [StringLength(50)]
        [FirstCapitalLetter]
        [Required]
        public string Name { get; set; }

        [StringLength(50)]
        [FirstCapitalLetter]
        [Required]
        public string Surname { get; set; }
        [Required]
        public TypeOfDocument TypeOfDocument { get; set; }
        [Required]
        public int DocumentNumber { get; set; }

        [DataType(DataType.Date)]
        [JsonPropertyName("DateOfBirth")]
        [JsonConverter(typeof(DateConverter))]
        [Required]
        public DateTime DateOfBirth { get; set; }

    }
}
