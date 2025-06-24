using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BokkStoreProject.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        [Display(Name ="List Price")]
        [Range(1 , 1000)]
        public double ListPrice { get; set; }
        [Required]
        [Display(Name ="Price for 1-50")]
        public double Price { get; set; }
        [Required]
        [Display(Name ="Price for 50+")]
        
        public double Price50 { get; set; }
        [Required]
        [Display(Name ="Price for 100+")]
    
        public double Price100 { get; set; }
        [Display(Name ="ImageURL")]
        public string? URL { get; set; }
        [Display(Name ="Category Name")]
        public int CategoryID { get; set; }
   
        public Category ?category { get; set; }
    }
}
