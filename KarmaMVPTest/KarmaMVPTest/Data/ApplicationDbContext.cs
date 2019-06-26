using KarmaMVPTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarmaMVPTest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options)
            :base(options)
        {

        }
        DbSet<Product> Products { get; set; }
        DbSet<Subcategory> Subcategories { get; set; }
        DbSet<Category> Categories { get; set; }
    }
}
