using FirstProject.Data;
using FirstProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstProject.Pages.Admin
{
    public class AddModel : PageModel
    {
        [BindProperty]             //input ha ro vasl mikone be maghadirshon
        public AddEditProductViewModel Product { get; set; }

        FirstProjectContext _firstProjectContext;

        public AddModel(FirstProjectContext firstProjectContext)
        {
            _firstProjectContext = firstProjectContext;
        }

        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            var item = new Item()
            {
                Price = Product.Price,
                QuantityInStock = Product.Quintityinstock
            };
            _firstProjectContext.Add(item);
            _firstProjectContext.SaveChanges();

            var pro = new Product()
            {
                Name = Product.Name,
                Description = Product.Discreption,
                Item = item
            };

            _firstProjectContext.Add(pro);
            _firstProjectContext.SaveChanges();

            pro.ItemId = pro.Id;
            _firstProjectContext.SaveChanges();

            if (Product.Picture?.Length > 0)
            {

                string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "images",
                    pro.Id + Path.GetExtension(Product.Picture.FileName));
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Product.Picture.CopyTo(stream);
                }
            }

            return RedirectToPage("Index");
        }
    }
}
