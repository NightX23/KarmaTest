using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KarmaMVPTest.Models
{
    public class Product
    {
        public Product()
        {
            UserIdTESTING = 0;
        }
        public int Id { get; set; }

        //FK USER--------------------------------------
        
        public int UserIdTESTING { get; set; }
        //---------------------------------------------
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        //FK SUBCATEGORY-------------------------------
        public int SubcategoryId { get; set; }
        
        [ForeignKey("SubcategoryId")]
        public virtual Subcategory Subcategory { get; set; }
        //---------------------------------------------

        public string Condition { get; set; }

        public bool PublicationStatus { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de creacion")]
        public DateTime CreationDate { get; set; }
    }
}
