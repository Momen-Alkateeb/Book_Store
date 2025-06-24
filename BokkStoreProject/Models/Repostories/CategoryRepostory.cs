namespace BokkStoreProject.Models.Repostories
{
    public class CategoryRepostory:ICategoryReposetory
    {

        private AppDbContext _context;
        public CategoryRepostory(AppDbContext context) {
            _context = context;

        }
        public void AddNewCategory(Category newcategory)
        {
            _context.Categories.Add(newcategory);
            Save();
        }
        public List<Category> GetAllCategories()
        {
           
            return _context.Categories.ToList();
        }
        public bool RemoveCategory(int id)
        {
            Category c1 = _context.Categories.FirstOrDefault(C => C.Id == id)!;
            if(c1 == null)
            {
                return false;
            }
            _context.Categories.Remove(c1);
            Save();
            return true;
        }
        public void UpdateCategory(Category newCategory)
        {
            Category oldCategory = _context.Categories.FirstOrDefault(C => C.Id == newCategory.Id);
            oldCategory.Name = newCategory.Name;
            oldCategory.DsiplayOrder = newCategory.DsiplayOrder;
            _context.Categories.Update(oldCategory);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
        public Category GetById(int id)
        {
            Category C1 = _context.Categories.FirstOrDefault(C => C.Id == id)!;
            return C1;
        }
    }
}
