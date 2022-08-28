using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace FirstProject.Models
{
    public class OrderDetail
    {
        [Key]
        public int DetailId { get; set; }
        [Required]
        public int Orderid { get; set; }
        [Required]
        public int Productid { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Count { get; set; }
        




        public Order Order { get; set; }

        [ForeignKey("Productid")]      //chon asm productid ba id product brabar nist bayad behesh befahmonim
        public Product Product { get; set; }
    }
}
