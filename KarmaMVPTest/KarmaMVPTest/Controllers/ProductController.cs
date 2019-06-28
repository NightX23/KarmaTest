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
            var products = _repository.GetProductsList();

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

        //POST: /Create
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

        //GET: /Product/Edit/#id
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CategorySubAndProducthViewModel model = new CategorySubAndProducthViewModel
            {
                ProductObj = _repository.GetProduct(id),
                CategoriesList = _repository.GetCategories(),
                SubcategoriesList = _repository.GetSubcategories()
            };

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        //POST: /Product/Edit/#id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit (CategorySubAndProducthViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            else
            {
                var ProductInDB = _repository.GetProduct(model.ProductObj.Id);

                if (ProductInDB == null)
                {
                    return NotFound();
                }
                else
                {
                    ProductInDB.Title = model.ProductObj.Title;
                    ProductInDB.Description = model.ProductObj.Description;
                    ProductInDB.SubcategoryId = model.ProductObj.SubcategoryId;
                    ProductInDB.Condition = model.ProductObj.Condition;
                    //ProductInDB.PublicationStatus = model.ProductObj.PublicationStatus;
                    await _repository._db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return RedirectToAction(nameof(Index));
        }


        //GET: /Product/Delete/#id
        public IActionResult Delete (int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product product = _repository.GetProduct(id);

            if(product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deleting(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _repository.GetProduct(id);

            if(product == null)
            {
                return NotFound();
            }

            _repository._db.Remove(product);
            await _repository._db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository._db.Dispose();
            }
        }
    }
}