using KarmaMVPTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarmaMVPTest.ViewModels
{
    public class CategorySubAndProducthViewModel
    {
        public List<Category> CategoriesList { get; set; }
        public List<Subcategory> SubcategoriesList { get; set; }
        public Product ProductObj { get; set; }
    }
}
