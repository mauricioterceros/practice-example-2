using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ProductAPI.Models;
using ProductAPI.Services;

namespace ProductAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Product
        /**
         * This method returns a list of all products.
         * @return List<Product> - A list of all products.
         */
        [HttpGet]
        public List<Product> GetAll()
        {
            // ProductService util = new ProductService();
            return _productService.GetAll();
        }

        // GET: api/Product/{id}
        /**
         * This method returns a list of all products.
         * @return List<Product> - A list of all products.
         */
        [HttpGet("{id}")]
        public Product GetById(int id)
        {
            Product product = _productService.GetById(id);
            //....
            product.Name = "Product Name";
            return product;
        }

        // POST: api/Product
        /**
         * This method creates a new product.
         * @param product - The product to create.
         * @return Product - The created product.
         */
        [HttpPost]
        public Product Create(Product product)
        {
            return _productService.Create(product);
        }

        // PUT: api/Product/{id}
        /**
         * This method updates an existing product.
         * @param id - The ID of the product to update.
         * @param updatedProduct - The updated product information.
         * @return Product - The updated product.
         */
        [HttpPut("{id}")]
        public Product Update(int id, Product updatedProduct)
        {
            return _productService.Update(id, updatedProduct);
        }

        // DELETE: api/Product/{id}
        /**
         * This method deletes a product by its ID.
         * @param id - The ID of the product to delete.
         * @return Product - The deleted product.
         */
        [HttpDelete("{id}")]
        public Product Delete(int id)
        {
            return _productService.Delete(id);
        }
    }
}