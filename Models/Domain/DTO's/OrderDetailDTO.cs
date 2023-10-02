using System.ComponentModel.DataAnnotations;

namespace TestApiRest.DTO_s
{
    public class OrderDetailDTO
    {
        public int IdDetail { get; set; }
        public int IdOrder  { get; set; }
        [Required]
        public int IdBook { get; set; }

    }
}
