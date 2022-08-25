using FirstProject.Models;

namespace FirstProject.Data.Repositories
{
    public interface IGroupRepository
    {
       IEnumerable<Category> getAllCategories();
       IEnumerable<ShowCategories> showCategories();

    }
}
