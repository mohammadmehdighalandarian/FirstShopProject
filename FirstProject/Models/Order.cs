using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstProject.Models
{
    public class Order
    {
        [Key]
        public int Orderid { get; set; }

        [Required]
        public int Userid { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        public bool IsFinally { get; set; }



        [ForeignKey("Userid")]
        public Users Users { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

      
    }

}
