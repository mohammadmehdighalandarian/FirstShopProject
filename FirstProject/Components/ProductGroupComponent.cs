using FirstProject.Data;
using FirstProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Components
{
    public class ProductGroupComponent:ViewComponent
    {
        private FirstProjectContext _firstProject;

        public ProductGroupComponent(FirstProjectContext firstProject)
        {
            _firstProject = firstProject;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var Categories = _firstProject
                .Categories
                .Select(c => new ShowCategories()
                {
                    GroupId = c.Id,
                    name = c.Name,
                    ProductCount = _firstProject.CategoryToProducts.Count(g=>g.CategoryId==c.Id)
                }).ToList();
            return View("/Views/Components/ProductGropupsComponent.cshtml", Categories);
        }
    }
}
