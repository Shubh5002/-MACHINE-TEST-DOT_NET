using DOTMACHINETEST.Context;
using DOTMACHINETEST.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList;
using System.Linq.Expressions;
using System.Reflection;

namespace DOTMACHINETEST.Controllers
{
    public class ProductController : Controller
    {

     
            private readonly ApplicationDbContext _context;

            public ProductController(ApplicationDbContext context)
            {
                _context = context;
            }

            // GET: Product
            public IActionResult GetProduct(int? page)
            {

            List<Product> products= _context.Products.Include(p => p.Category).ToList();

            //return View(GetProjects().ToPagedList(pageNumber, pageSize));
            //List<Product> products=_context.Products.ToList();

            return View(products);
        }

            // GET: Product/Create
            public IActionResult AddProduct()
            {
                PopulateCategoriesDropdown();
                return View();
            }

        // POST: Product/Create
        // POST: Product/Create
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            
                // Get the selected category by its ID
                var category = _context.Categories.Find(product.CategoryId);
                if (category == null)
                {
                    ModelState.AddModelError(string.Empty, "Invalid category selection.");
                    PopulateCategoriesDropdown();
                    return View(product);
                }

                // Associate the category with the product
                product.Category = category;

                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(GetProduct));
            

            PopulateCategoriesDropdown();
            return View(product);
        }

        // GET: Product/Edit/5
        public IActionResult EditProduct(int id)
            {
                var product = _context.Products.Find(id);
                if (product == null)
                {
                    return NotFound();
                }

                PopulateCategoriesDropdown();
                return View(product);
            }

            // POST: Product/Edit/5
            [HttpPost]
            public IActionResult EditProduct(int id, Product product)
            {
                if (id != product.ProductId)
                {
                    return NotFound();
                }

               
                    _context.Products.Update(product);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(GetProduct));
                

                PopulateCategoriesDropdown();
                return View(product);
            }

            // GET: Product/Delete/5
            public IActionResult DeleteProduct(int id)
            {
                var product = _context.Products.Find(id);
                if (product == null)
                {
                    return NotFound();
                }

                return View(product);
            }

            // POST: Product/Delete/5
            [HttpPost, ActionName("Delete")]
            public IActionResult DeleteConfirmed(int ProductId)
            {
                var product = _context.Products.Find(ProductId);
                if (product == null)
                {
                    return NotFound();
                }

                _context.Products.Remove(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(GetProduct));
            }


        //GetProductByPagination
        

 

        private void PopulateCategoriesDropdown()
        {
            ViewBag.Categories = new SelectList(_context.Categories, "CategoryId", "CategoryName");
        }
    }
    }


