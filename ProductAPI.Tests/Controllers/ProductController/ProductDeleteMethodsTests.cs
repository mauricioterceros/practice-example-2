using Xunit;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Controllers;
using ProductAPI.Models;
using ProductAPI.Tests.Utils;
using ProductAPI.Services;

namespace ProductAPI.Controllers.UnitTests
{
    public class ProductDeleteMethodsTests
    {
        [Fact]
        public void DeleteProduct_ExistingId_ReturnsDeletedProduct()
        {
            // Arrange - Given
            ProductService productService = new ProductService();
            productService.Create(new Product { Id = 1, Name = "Product1", Price = 10.0 });
            productService.Create(new Product { Id = 2, Name = "Product2", Price = 20.0 });
            ProductController controller = new ProductController(productService);
            int productId = 1;
            
            // Act - When
            Product productDeleted = controller.Delete(productId);
            int productCount = controller.GetAll().Count();

            // Assert - Then
            Assert.NotNull(productDeleted);
            Assert.Equal(productId, productDeleted.Id);
            Assert.Equal("Product1", productDeleted.Name);
            Assert.Equal(10.0, productDeleted.Price);
            Assert.Equal(1, productCount);
        }
    }
}