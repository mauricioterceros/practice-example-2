using ProductAPI.Models;
using ProductAPI.Controllers;
using ProductAPI.Services;
using ProductAPI.Tests.Stubs;

namespace ProductAPI.Tests.Utils
{
    public static class ProductUtils
    {
        public static List<Product> GetTestProducts()
        {
            return new List<Product>
            {
                new Product { Id = 1, Name = "Product1", Price = 10.0 },
                new Product { Id = 2, Name = "Product2", Price = 20.0 }
            };
        }

        public static ProductController GetTestProductControllerStub()
        {
            ProductController controller = new ProductController(new ProductServiceStub());
            return controller;
        }
    }
}
