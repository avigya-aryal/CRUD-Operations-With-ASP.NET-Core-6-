using BulkyBookWeb.Models;

namespace BulkyBookWeb.Repository
{
    public interface ICategory
    {
        List<Category> GetAll();
        Category Create(Category category);
        Category GetById(int id);
        Category Edit(Category category);
        Category Delete(Category category);
    }
}
