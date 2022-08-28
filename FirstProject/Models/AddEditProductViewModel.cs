using Microsoft.EntityFrameworkCore.Diagnostics;

namespace FirstProject.Models
{
    public class AddEditProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discreption { get; set; }
        public int Quintityinstock { get; set; }
        public decimal Price { get; set; }
        public IFormFile Picture { get; set; }
    }
}
