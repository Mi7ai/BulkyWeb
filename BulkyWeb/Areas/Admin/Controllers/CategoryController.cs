using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bulky.Data;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bulky.DataAccess.Repository.IRepository;


namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            if (_unitOfWork.Category != null)
            {
                List<Category> categories = _unitOfWork.Category.GetCategories().ToList();
                return View(categories);
            }

            return NotFound();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {

            //Custom Validation
            if (category.Name != null && category.Name.Equals(category.DisplayOrder.ToString(), StringComparison.Ordinal))
            {
                ModelState.AddModelError("name", "The Category name must be different from Display order");
            }

            if (ModelState.IsValid)
            {              
                //Add and save to db
                _unitOfWork.Category.Add(category);
                _unitOfWork.Save();
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

            Category categoryFromDb = _unitOfWork.Category.Get(i => i.Id == id);

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
                _unitOfWork.Category.Update(category);
                _unitOfWork.Save();
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

            Category? categoryFromDb = _unitOfWork.Category.Get(i => i.Id == id);

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
            Category? categoryFromDb = _unitOfWork.Category.Get(i => i.Id == category.Id);

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(categoryFromDb);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}

