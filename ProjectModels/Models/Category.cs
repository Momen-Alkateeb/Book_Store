using System.ComponentModel.DataAnnotations;

namespace BokkStoreProject.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Must be Filling this Filed")]
        [Display(Name="Category Name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Must be Filling this Filed")]
        [Range(1 ,1000)]
        [Display(Name="Display Order")]
        public int DsiplayOrder { get; set; }
    }
}
