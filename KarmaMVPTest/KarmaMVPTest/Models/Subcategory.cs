using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KarmaMVPTest.Models
{
    public class Subcategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //FK CATEGORY-----------------------
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        //----------------------------------
    }
}
