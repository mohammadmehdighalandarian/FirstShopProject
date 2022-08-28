using System.ComponentModel.DataAnnotations;

namespace FirstProject.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(300)]
        public string Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        [Required]
        public DateTime DateTime { get; set; }


        public List<Order> Orders { get; set; }
    }
}
