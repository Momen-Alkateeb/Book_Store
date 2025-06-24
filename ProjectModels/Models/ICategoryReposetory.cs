using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BokkStoreProject.Models
{
    public interface ICategoryReposetory
    {
        public List<Category> GetAllCategories();
        public bool RemoveCategory(int id);
        public void AddNewCategory(Category category);
        public void UpdateCategory(Category newCategory);

        public void Save();
        public Category GetById(int id);
    }
}
