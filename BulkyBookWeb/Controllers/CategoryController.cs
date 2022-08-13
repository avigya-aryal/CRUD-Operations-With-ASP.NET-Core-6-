using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using BulkyBookWeb.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ICategory _categoryRepo;

        public CategoryController(ICategory categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }


        public IActionResult Index()
        {
            List<Category> categories = _categoryRepo.GetAll();
            return View(categories);
        }


        public IActionResult Create()
        {
            
            Category category = new Category();
            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            try
            {
                category = _categoryRepo.Create(category);
            }
            catch
            {

            }
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Details(int id)
        {
            Category category = _categoryRepo.GetById(id);
            return View(category);
        }

        
        public IActionResult Edit(int id)
        {
            Category category = _categoryRepo.GetById(id);
            return View(category);
        }


        [HttpPost]
        public IActionResult Edit(Category category)
        {
            try
            {
                category = _categoryRepo.Edit(category);
            }
            catch
            {

            }
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int id)
        {
            Category category = _categoryRepo.GetById(id);
            return View(category);
        }


        [HttpPost]
        public IActionResult Delete(Category category)
        {
            try
            {
                category = _categoryRepo.Delete(category);
            }
            catch
            {

            }
            return RedirectToAction(nameof(Index));
        }
    }
}
