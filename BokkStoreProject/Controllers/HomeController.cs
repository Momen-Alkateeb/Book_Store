using System.Diagnostics;
using BokkStoreProject.Models;
using BokkStoreProject.Models.Repostories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BokkStoreProject.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepostory _product;

        public HomeController(IProductRepostory Product)
        {
            _product = Product;
        }
        [Authorize]
        public IActionResult Index(string? Title)
        {
            if (Title != null)
            {
                var Product = _product.GetByTitle(Title);
                if (Product == null)
                {
                    TempData["Found"] = "The Product not Found";
                   // return View("PartialDetails");
                }


                return View("ProductDetails", Product);
                


            }
         
               var products = _product.GetAll();

            return View("Index" , products);
        }

      
        public IActionResult Details(int id)
        {

            var Product = _product.GetById(id);
            return View("ProductDetails", Product);
        }
      



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
