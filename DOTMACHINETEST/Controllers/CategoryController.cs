using DOTMACHINETEST.Context;
using DOTMACHINETEST.Models;
using Microsoft.AspNetCore.Mvc;

namespace DOTMACHINETEST.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Category
        public IActionResult GetCategory()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }

        // GET: Category/Create
        public IActionResult AddCategory()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction(nameof(GetCategory));
            
            return View(category);
        }

        // GET: Category/Edit/5
        public IActionResult EditCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public IActionResult EditCategory(int id, Category category)
        {
            if (id != category.CategoryId)
            {
                return NotFound();
            }

            
                _context.Categories.Update(category);
                _context.SaveChanges();
                return RedirectToAction(nameof(GetCategory));
            
            return View(category);
        }
        [HttpGet]
        public IActionResult DeleteCategoryData(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int CategoryId)
        {
            var category = _context.Categories.Find(CategoryId);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(GetCategory));
        }

        // GET: Category/Delete/5
        public IActionResult DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        //// POST: Category/Delete/5
        //[HttpPost, ActionName("Delete")]
        //public IActionResult DeleteConfirmed(int CategoryId)
        //{
        //    var category = _context.Categories.Find(CategoryId);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Categories.Remove(category);
        //    _context.SaveChanges();
        //    return RedirectToAction(nameof(GetCategory));
        //}

    }
}
