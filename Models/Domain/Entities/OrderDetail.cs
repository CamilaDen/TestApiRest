using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApiRest.Domain.Entities
{
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDetail { get; set; }

        [ForeignKey("IdOrder")]
        public Order Order { get; set; }
        public int IdOrder { get; set; }
        [ForeignKey("IdBook")]
        public Book Book { get; set; }
        public int IdBook { get; set; }
        
    }
}
