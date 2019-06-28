using KarmaMVPTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarmaMVPTest.Data
{
    public class ApplicationRepository
    {
        public ApplicationDbContext _db {get; }

        public ApplicationRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        
        //PRODUCTS QUERIES---------------------------------------
        public List<Category> GetCategories()
        {
            return _db.Categories.ToList();
        }

        public List<Subcategory> GetSubcategories()
        {
            return _db.Subcategories.Include(s =>s.Category).ToList();
        }

        public List<Product> GetProductsList()
        {
            return _db.Products.Where(p => p.UserIdTESTING == 0).Include(p => p.Subcategory)
                .Include(p => p.Subcategory.Category).ToList();
        }

        public Product GetProduct(int id)
        {
            return _db.Products.SingleOrDefault(p => p.Id == id);
        }
        //-----------------------------------------------------------------------------------------
    }
}
