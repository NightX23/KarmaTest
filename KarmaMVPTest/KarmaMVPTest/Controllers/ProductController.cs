using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KarmaMVPTest.Data;
using KarmaMVPTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KarmaMVPTest.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var products = _db.Products.Where(p => p.UserIdTESTING == 0).Include(p => p.Subcategory)
                .Include(p => p.Subcategory.Category).ToList();

            return View(products);
        }

        //Create GET
        public IActionResult Create()
        {
            Product productObj = new Product();

            return View(productObj);
        }

        //Create POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _db.Add(product);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }
    }
}