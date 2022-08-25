using FirstProject.Models;

namespace FirstProject.Data.Repositories
{
    public class GroupRepository:IGroupRepository
    {
        private FirstProjectContext _firstProjectContext;

        public GroupRepository(FirstProjectContext firstProjectContext)
        {
            _firstProjectContext = firstProjectContext;
        }

        public IEnumerable<Category> getAllCategories()
        {
            return _firstProjectContext.Categories;
        }

        public IEnumerable<ShowCategories> showCategories()
        {
            return _firstProjectContext
                .Categories
                .Select(c => new ShowCategories()
                {
                    GroupId = c.Id,
                    name = c.Name,
                    ProductCount = _firstProjectContext.CategoryToProducts.Count(g => g.CategoryId == c.Id)
                }).ToList();
        }
    }
}
