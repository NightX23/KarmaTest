using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KarmaMVPTest.Data;
using KarmaMVPTest.Models;
using KarmaMVPTest.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KarmaMVPTest.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationRepository _repository;

        public ProductController(ApplicationRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var products = _repository.GetProducts();

            return View(products);
        }

        //Create GET
        public IActionResult Create()
        {
            CategorySubAndProducthViewModel model = new CategorySubAndProducthViewModel
            {
                CategoriesList = _repository.GetCategories(),
                SubcategoriesList = _repository.GetSubcategories()
            };

            return View(model);
        }

        //Create POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategorySubAndProducthViewModel model)
        {
            if (ModelState.IsValid)
            {
                _repository._db.Add(model.ProductObj);
                await _repository._db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var newmodel = new CategorySubAndProducthViewModel
            {
                CategoriesList = _repository.GetCategories(),
                SubcategoriesList = _repository.GetSubcategories()
            };

            return View(newmodel);
        }
    }
}