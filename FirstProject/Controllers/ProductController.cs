using FirstProject.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.Controller
{
    public class ProductController : Microsoft.AspNetCore.Mvc.Controller
    {
        private FirstProjectContext _firstProjectContext;

        public ProductController(FirstProjectContext firstProjectContext)
        {
            _firstProjectContext = firstProjectContext;
        }
        public IActionResult ShowProductsinCategory(int id)
        {
            var Products = _firstProjectContext
                .CategoryToProducts
                .Where(x => x.CategoryId == id)
                .Include(x => x.Product)
                .Select(x => x.Product)
                .ToList();

            ViewData["CategoryName"] = _firstProjectContext.Categories.Find(id).Name;
            return View(Products);
            
        }
    }
}
