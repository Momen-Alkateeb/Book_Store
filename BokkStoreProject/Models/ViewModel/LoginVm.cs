using System.ComponentModel.DataAnnotations;

namespace BokkStoreProject.Models.ViewModel
{
    public class LoginVm
    {
        [Required]
        [Display(Name ="User Name")]
        public string Name { get; set; }
        
   
        [Required]
        public string Password { get; set; }    

        public bool RememberMe { get; set; }
    }
}
