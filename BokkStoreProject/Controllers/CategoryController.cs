
using Microsoft.AspNetCore.Mvc;
using BokkStoreProject.Models;
using BokkStoreProject.Models.Repostories;

namespace BokkStoreProject.Controllers
{
    public class CategoryController : Controller

    {
        private ICategoryReposetory category;
        public CategoryController(ICategoryReposetory _category) { 
           category = _category;
        
        }
        [Route("/AllCategory")]
        public IActionResult Index()
        {
            List<Category> AllCategory = category.GetAllCategories();

            return View("Index" , AllCategory);
        }
        [Route("/AddData")]
        public IActionResult AddNewData()
        {
            return View("SaveNewData");
        }
       
        public IActionResult SaveNewData(Category newcategory)
        {
            if(ModelState.IsValid)
            {
                category.AddNewCategory(newcategory);
                TempData["Success"] = "Save Data Successfully";
                return RedirectToAction("Index");
            }
            return View("AddCategory", newcategory);
        }
        public IActionResult UpdateData(int id)
        {

            Category C1 = category.GetById(id);
            return View("UpdateData", C1);
        }
        public IActionResult SaveUpdateData(Category newcategory)
        {
            if (ModelState.IsValid)
            {
                category.UpdateCategory(newcategory);
                TempData["Success"] = "Update data Successfully";
                return RedirectToAction("Index");
            }
            return View("UpdateData", newcategory);
        }
        public IActionResult DeleteData(int id)
        {
           if(category.RemoveCategory(id))
            {
                TempData["Success"] = "Removed Category Successfully";
            }
            else
            {
                TempData["Error"] = "Romved Category Failed";
            }
                return RedirectToAction("Index");
        }
    }
}
