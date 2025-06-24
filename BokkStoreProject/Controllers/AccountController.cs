using System.Threading.Tasks;
using BokkStoreProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;

namespace BokkStoreProject.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _ManageUser;
        private  SignInManager<ApplicationUser> _SignInManager;
        private RoleManager<IdentityRole> _MangerRole;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> SignInManager,   RoleManager<IdentityRole> MangerRole) { 
             _ManageUser = userManager;
            _SignInManager = SignInManager;
            _MangerRole = MangerRole;
        }
      
        public IActionResult Register()
        {
            return View("Register");
        }
        public async Task<IActionResult> SaveRegister (RegisterVm InfoReg)
        {
            ApplicationUser newuser = new ApplicationUser();
            if (ModelState.IsValid)
            {
                newuser.UserName = InfoReg.Name;
              
                newuser.Address = InfoReg.Address;
                newuser.Email  = InfoReg.Email;
               IdentityResult results =  await _ManageUser.CreateAsync(newuser , InfoReg.Password);
                if (results.Succeeded)
                {
                    await _SignInManager.SignInAsync(newuser, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var item in results.Errors)
                    {
                        ModelState.AddModelError(" ",item.Description);
                    }        
                }

                
            }
            
            return View("Register", InfoReg);
        }
        public IActionResult Login()
        {
            return View("Login");
        }
        [Route("CheckLogin")]
        public  async Task< IActionResult> SaveLogin(LoginVm loginfo)
        {
            if (ModelState.IsValid)
            {

            
               ApplicationUser User =  await _ManageUser.FindByNameAsync(loginfo.Name);
                if(User != null)
                {
                    var isPasswordValid = await _ManageUser.CheckPasswordAsync(User, loginfo.Password);
                    if(isPasswordValid) {
                        await _SignInManager.SignInAsync(User, loginfo.RememberMe);
                        return RedirectToAction("Index", "Home");

                    }
                }
                ModelState.AddModelError("", "User Name or Password Not Corecct");
            }
            return View("Login", loginfo);
        }
        public async Task<IActionResult> Logout()
        {
          await  _SignInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        public IActionResult AddRole()
        {
            return View("AddRole");
        }
        public async Task<IActionResult> SaveRole(AddRole role)
        {
            IdentityRole Role = new IdentityRole();
            Role.Name = role.RoleName;
            if (ModelState.IsValid)
            {
                var result = await _MangerRole.CreateAsync(Role);
                if (result.Succeeded)
                {
                    TempData["Success"] = "Create Role Successfully";
                    return RedirectToAction("index" , "Home");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("",item.Description);
                    }
                }
            }
            return View("AddRole",role);
        }
        public IActionResult AddUserToRole()
        {

            ViewBag.Roles = _MangerRole.Roles.ToList();
            return View("AddUserToRole");
        }
        public async Task<IActionResult> SaveUsertToRole(AddUserToRoleVM info)
        {
            ApplicationUser User = new ApplicationUser();
            if (ModelState.IsValid)
            {


                User.UserName = info.Name;
              
                User.Address = info.Address;
                User.Email = info.Email;
                IdentityResult result = await _ManageUser.CreateAsync(User, info.Password);
                if (result.Succeeded)
                {
                    IdentityResult isregister = await _ManageUser.AddToRoleAsync(User, info.RoleName);
                    if (isregister.Succeeded)
                    {
                        TempData["Success"] = $"Add {info.Name} To {info.RoleName} Succefully";
                        return RedirectToAction("Index", "Home");
                    }

                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            ViewBag.Roles = _MangerRole.Roles.ToList();
            return View("AddUserToRole" , info);
        }




    }
}
