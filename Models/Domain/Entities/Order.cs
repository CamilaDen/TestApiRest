using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestApiRest.Domain.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdOrder { get; set; }
        [ForeignKey("IdUser")]
        public User User { get; set; }
        public int IdUser { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateOfOrder { get; set; }
        public List<OrderDetail> OrderDetailList { get; set; }

    }
}
