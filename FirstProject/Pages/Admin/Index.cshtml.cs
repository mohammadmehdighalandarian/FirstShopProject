using FirstProject.Data;
using FirstProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private FirstProjectContext _firstProject;

        public IndexModel(FirstProjectContext firstProject)
        {
            _firstProject = firstProject;
        }
        public IEnumerable<Product> Products { get; set; }
        public void OnGet()
        {
            Products = _firstProject.Products.Include(x=>x.Item);
        }

        public void OnPost()
        {

        }
    }
}
