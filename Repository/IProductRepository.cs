using WebAppy.Models;

namespace WebAppy.Repository
{
    public interface IProductRepository
    {
        Product Find(int Id);
        List<Product> GetAll();
        Product Add(Product product);
        Product Update(Product product);
        void Delete(int id);
    }
}
