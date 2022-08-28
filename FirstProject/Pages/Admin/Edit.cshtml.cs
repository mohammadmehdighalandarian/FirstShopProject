using FirstProject.Data;
using FirstProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.Pages.Admin
{
    public class EditModel : PageModel
    {
        [BindProperty]             //input ha ro vasl mikone be maghadirshon
        public AddEditProductViewModel Product { get; set; }

        FirstProjectContext _firstProjectContext;

        public EditModel(FirstProjectContext firstProjectContext)
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var product = _firstProjectContext.Products.Find(Product.Id);
            var item = _firstProjectContext.Items.FirstOrDefault(x => x.Id == product.ItemId);

            product.Name = Product.Name;
            product.Description = Product.Discreption;
            item.Price = Product.Price;
            item.QuantityInStock = Product.Quintityinstock;

            _firstProjectContext.SaveChanges();


       

            if (Product.Picture?.Length > 0)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "images",
                    product.Id + Path.GetExtension(Product.Picture.FileName));
                System.IO.File.Delete(filePath);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Product.Picture.CopyTo(stream);
                }
            }

            return RedirectToPage("Index");
        }


    }
}
