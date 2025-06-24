using Microsoft.AspNetCore.Identity;

namespace BokkStoreProject.Models
{
    public class ApplicationUser:IdentityUser
    {
       public  string Address { get; set; }
    }
}
