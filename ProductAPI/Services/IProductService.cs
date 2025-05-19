using ProductAPI.Models;

namespace ProductAPI.Services
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetById(int id);
        Product Create(Product product);
        Product Update(int id, Product updatedProduct);
        Product Delete(int id);
    }
}