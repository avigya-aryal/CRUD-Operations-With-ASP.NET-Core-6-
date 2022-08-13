using BulkyBookWeb.Data;
using BulkyBookWeb.Models;

namespace BulkyBookWeb.Repository
{
    public class CategoryRepository : ICategory
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CategoryRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Category Create(Category category)
        {
            _applicationDbContext.Categories.Add(category);
            _applicationDbContext.SaveChanges();
            return category;
        }

        public Category GetById(int id)
        {
            Category category = _applicationDbContext.Categories.FirstOrDefault(c => c.Id == id);
            return category;
        }

        public List<Category> GetAll()
        {
            List<Category> categories = _applicationDbContext.Categories.ToList();
            return categories;
        }

        public Category Edit(Category category)
        {
            _applicationDbContext.Categories.Attach(category);
            _applicationDbContext.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _applicationDbContext.SaveChanges();
            return category;
        }

        public Category Delete(Category category)
        {
            _applicationDbContext.Categories.Attach(category);
            _applicationDbContext.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _applicationDbContext.SaveChanges();
            return category;
        } 
    }
}
