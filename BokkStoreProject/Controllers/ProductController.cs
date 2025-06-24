using BokkStoreProject.Models;
using BokkStoreProject.Models.Repostories;
using BokkStoreProject.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Build.Evaluation;

namespace BokkStoreProject.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepostory Product;
        private ICategoryReposetory Categorey;
        private IWebHostEnvironment _webHostEnvironment;
        public ProductController(IProductRepostory _product , ICategoryReposetory _category, IWebHostEnvironment webHostEnvironment)
        {
            Product = _product;
            Categorey = _category;
            _webHostEnvironment = webHostEnvironment;
        }
        [Route("/AllProducts")]
        public IActionResult Index()
        {
           

            var Products = Product.GetAll();
            return View("ProductIndex", Products) ;
        }
        public IActionResult UpdateProduct(int id)
        {

            ProductVM P1 = new ProductVM();
            P1.products = Product.GetById(id);
            P1.Category = Categorey.GetAllCategories();
            return View("Update", P1);
        }
       
        public IActionResult SaveUpdateProduct(ProductVM productsvm , IFormFile file )
        {
            string WWWRootPath = _webHostEnvironment.WebRootPath;
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string PathProduct = Path.Combine(WWWRootPath, @"Images/Product");
                    using (var filestream = new FileStream(Path.Combine(PathProduct, filename), FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }

                    if (productsvm.products.URL != null)
                    {
                        var oldpath = Path.Combine(WWWRootPath, productsvm.products.URL.TrimStart('/'));
                        if (System.IO.File.Exists(oldpath))
                        {
                            System.IO.File.Delete(oldpath);
                        }
                    }
                    productsvm.products.URL =  @"/Images/Product/"+filename ;
                }
                if(productsvm.products.CategoryID != 0)
                {
                    Product.UpdateProduct(productsvm.products);
                    TempData["Success"] = "Update Product Sucsessflly";
                    return RedirectToAction("Index");
               
                }
                ModelState.AddModelError("CategoryID", "Must Be Choosing Categorey");
            

            }
            productsvm.Category = Categorey.GetAllCategories();
            return View("Update", productsvm);

        }
        public IActionResult AddNewProduct()
        {
            ProductVM productvm = new ProductVM();
            productvm.Category = Categorey.GetAllCategories();
            return View("CreateProduct" , productvm);
        }
        public IActionResult SaveNewProduct(ProductVM newProduct ,IFormFile file )
        {
            string WWWRootPath = _webHostEnvironment.WebRootPath;

            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string ProductPath = Path.Combine(WWWRootPath, @"Images/Product");
                    using (var filestream = new FileStream(Path.Combine( ProductPath,filename), FileMode.Create))
                    {
                        file.CopyTo(filestream);
                    }
                    newProduct.products.URL = @"/Images/Product"+filename;
                }
                
                    TempData["Success"] = "Add Product Sucsessflly";
                    Product.CreatProduct(newProduct.products);
                    return RedirectToAction("Index");
                 
            }
            newProduct.Category = Categorey.GetAllCategories();
            return View("CreateProduct", newProduct);
        }
        public ActionResult DeleteProduct(int id)
        {
            Product.RemoveProduct(id);
            TempData["Success"] = "Remove Product Sucsessflly";
            return RedirectToAction("Index");
        }
    }
}
