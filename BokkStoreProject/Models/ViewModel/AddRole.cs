using System.ComponentModel.DataAnnotations;

namespace BokkStoreProject.Models.ViewModel
{
    public class AddRole
    {
        [Display(Name ="Role Name")]
        [Required]
        public string RoleName { get; set; }
    }
}
