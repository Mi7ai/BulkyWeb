using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<Category> categoriesList = _dbContext.Categories.ToList();

            return View(categoriesList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                //Custom Validation
                if (category.Name != null && category.Name.Equals(category.DisplayOrder.ToString(), StringComparison.Ordinal))
                {
                    ModelState.AddModelError("name", "The Category name must be different from Display order");
                }

                //Add and save to db
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? categoryFromDb = _dbContext.Categories.FirstOrDefault(i => i.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                //Auto updates the fields based on the id of the category parameter
                _dbContext.Update(category);
                _dbContext.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? categoryFromDb = _dbContext.Categories.FirstOrDefault(i => i.Id == id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        /*
         I can change the method signature and pass in only the id.
        That will change like: [HttpPost,ActionName("Delete")] because there is already a method with the same signature.
        Explicitly tell the action name to be delete when posting the form
         */
        [HttpPost]
        public IActionResult Delete(Category category)
        {
            Category? categoryFromDb = _dbContext.Categories.Find(category.Id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            _dbContext.Remove(categoryFromDb);
            _dbContext.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}

