using Microsoft.EntityFrameworkCore;

namespace BokkStoreProject.Models.Repostories
{
    public class ProductReposotory:IProductRepostory
    {
        private AppDbContext _context;
        public ProductReposotory(AppDbContext Context)
        {
            _context=Context;
        }
        public List<Product> GetAll()
        {
            return _context.Products.Include(P => P.category).ToList();
        }
        public void CreatProduct(Product product)
        {
            _context.Add(product);
            Save();
        }
        public Product GetById(int id)
        {
            return _context.Products.Include(P=>P.category).FirstOrDefault(P => P.Id == id);
        }
        public Product GetByTitle(string title)
        {
            return _context.Products.Include(P=>P.category).FirstOrDefault(P => P.Title == title)!;
        }
        public void UpdateProduct(Product P2)
        {
            Product p1 = _context.Products.FirstOrDefault(P => P.Id == P2.Id)!;
            p1.Title = P2.Title;
            p1.Description = P2.Description;
            p1.ISBN = P2.ISBN;
            p1.Author = P2.Author;
            p1.ListPrice = P2.ListPrice;
            p1.Price = P2.Price;
            p1.Price50 = P2.Price50;
            p1.Price100 = P2.Price100;
            p1.URL = P2.URL;
            _context.Update(p1);
            Save();
        }
        public void RemoveProduct(int id)
        {
            Product P1 = _context.Products.FirstOrDefault(P => P.Id == id);
            _context.Remove(P1);
            Save();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
