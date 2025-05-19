using ProductAPI.Models;
using ProductAPI.Services;

namespace ProductAPI.Tests.Stubs
{
    public class ProductServiceStub : IProductService
    {
        private List<Product> _products;

        public ProductServiceStub()
        {
            _products = new List<Product>()
            {
                new Product { Id = 1, Name = "Product1", Price = 10.0 },
                new Product { Id = 2, Name = "Product2", Price = 20.0 }
            };
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);;
        }

        public Product Create(Product product)
        {
            product.Id = _products.Max(p => p.Id) + 1;
            return product;
        }

        public Product Update(int id, Product updatedProduct)
        {
            return updatedProduct;
        }

        public Product Delete(int id)
        {
            return _products[0];
        }
    }
}