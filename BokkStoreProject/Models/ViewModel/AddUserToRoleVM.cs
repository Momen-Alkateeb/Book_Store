using System.ComponentModel.DataAnnotations;

namespace BokkStoreProject.Models.ViewModel
{
    public class AddUserToRoleVM
    {

      
            [Required]
            [Display(Name = "User Name")]
            public string Name { get; set; }
            [Required]

            public string Password { get; set; }
            [Required]
            [Compare("Password")]
            [Display(Name = "Confirm Password")]
            public string ConfirmPassword { get; set; }
            [Required]
            public string Email { get; set; }
            [Required]
            public string Address { get; set; }
            [Display(Name="RoleName")]
            public string RoleName { get; set; }
        
    }

}

