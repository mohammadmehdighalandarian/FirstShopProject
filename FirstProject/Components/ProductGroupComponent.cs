using FirstProject.Data;
using FirstProject.Data.Repositories;
using FirstProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Components
{
    public class ProductGroupComponent:ViewComponent
    {
        private IGroupRepository groupRepository;

        public ProductGroupComponent(IGroupRepository groupRepository)
        {
            this.groupRepository = groupRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
           
            return View("/Views/Components/ProductGropupsComponent.cshtml", groupRepository.showCategories());
        }
    }
}
