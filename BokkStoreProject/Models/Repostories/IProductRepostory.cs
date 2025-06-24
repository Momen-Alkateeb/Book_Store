namespace BokkStoreProject.Models.Repostories
{
    public interface IProductRepostory
    {
        public List<Product> GetAll();
        public void CreatProduct(Product product);  
        public Product GetById(int id);
        public void UpdateProduct(Product newproduct);
        public Product GetByTitle(string title);
        public void RemoveProduct(int id);
        public void Save();
    }
}
