﻿using System;
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
                if (category.Name.Equals(category.DisplayOrder.ToString(), StringComparison.Ordinal))
                {
                    ModelState.AddModelError("name", "The Category name must be different from Display order");
                }

                //Add and save to db
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}

