using ProductAPI.Models;

namespace ProductAPI.Services
{
    public class ProductService : IProductService
    {
        private List<Product> _products;

        public ProductService()
        {
            _products = new List<Product>();
        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            var product = _products.Find(p => p.Id == id);
            if (product == null)
            {
                product = new Product { Id = -1, Name = "Not Found", Price = 0.0 };
            }
            return product;
        }

        public Product Create(Product product)
        {
            Product createdProduct;
            if (product.Price <= 0)
            {
                createdProduct = new Product { Id = -1, Name = product.Name + " / Price Not Available", Price = 0.0 };
                // devolver un mensaje de error
                // return BadRequest("Price must be greater than zero.");
            }
            else
            {
                product.Id =  _products.Count > 0 ? _products.Max(p => p.Id) + 1 : 1;
                _products.Add(product);
                createdProduct = product;
            }
            return createdProduct;
        }

        public Product Update(int id, Product updatedProduct)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;

            // return NoContent();
            return product;
        }

        public Product Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            /*if (product == null)
            {
                return NotFound();
            }*/

            _products.Remove(product);
            // return NoContent();
            return product;
        }
    }
}