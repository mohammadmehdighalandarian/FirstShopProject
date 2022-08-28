using FirstProject.Data;
using FirstProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.Pages.Admin
{
    public class RemoveModel : PageModel
    {
        [BindProperty]             //input ha ro vasl mikone be maghadirshon
        public AddEditProductViewModel Product { get; set; }

        FirstProjectContext _firstProjectContext;

        public RemoveModel(FirstProjectContext firstProjectContext)
        {
            _firstProjectContext = firstProjectContext;
        }

        public void OnGet(int id)
        {
            var pro = _firstProjectContext
                .Products
                .Include(x => x.Item)
                .Where(z => z.Id == id)
                .Select(k => new AddEditProductViewModel()
                {
                    Id = k.Id,
                    Name = k.Name,
                    Discreption = k.Description,
                    Price = k.Item.Price,
                    Quintityinstock = k.Item.QuantityInStock,

                })
                .FirstOrDefault();
            Product = pro;
        }

        public IActionResult OnPost()
        {
            

            var product = _firstProjectContext.Products.Find(Product.Id);
            var item = _firstProjectContext.Items.FirstOrDefault(x => x.Id == product.ItemId);

            _firstProjectContext.Items.Remove(item);
            _firstProjectContext.Products.Remove(product);

            _firstProjectContext.SaveChanges();

            string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot",
                "images",
                product.Id + ".jpg");
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            return RedirectToPage("Index");
        }
    }
}
