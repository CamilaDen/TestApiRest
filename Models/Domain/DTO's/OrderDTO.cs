using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using TestApiRest.Attributes;
using TestApiRest.DTO_s;

namespace TestApiRest.Domain.DTO_s
{
    public class OrderDTO
    {
        public int IdOrder { get; set; }
        [Required]
        public int IdUser { get; set; }
        [DataType(DataType.Date)]
        [JsonPropertyName("DateOfOrder")]
        [JsonConverter(typeof(DateConverter))]
        [Required]
        public DateTime DateOfOrder { get; set; }
        [Required]
        public List<OrderDetailDTO> OrderDetailList { get; set; }
    }
}
