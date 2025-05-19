using Xunit;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Controllers;
using ProductAPI.Models;
using ProductAPI.Tests.Utils;
using ProductAPI.Services;

namespace ProductAPI.Controllers.UnitTests
{
    public class ProductPostMethodsTests
    {
        // Unit Test
        [Fact]
        public void CreateProduct_ValidData_ReturnsProduct()
        {
            // Arrange - Given
            ProductController controller = ProductUtils.GetTestProductControllerStub();
            Product newProduct = new Product { Name = "Monitor Samsung 21 pulg.", Price = 499.99 };

            // Act - When
            Product createdProduct = controller.Create(newProduct);

            // Assert - Then
            Assert.NotNull(createdProduct);
            Assert.Equal(newProduct.Name, createdProduct.Name);
            Assert.Equal(newProduct.Price, createdProduct.Price);
            Assert.Equal(3, createdProduct.Id);
        }

        // Unit Test => Integration Test
        [Fact]
        public void CreateProduct_WithPriceZero_ReturnsDefaultProduct()
        {
            // Arrange - Given
            ProductService productService = new ProductService();
            productService.Create(new Product { Id = 1, Name = "Product1", Price = 10.0 });
            productService.Create(new Product { Id = 2, Name = "Product2", Price = 20.0 });
            ProductController controller = new ProductController(productService);
            Product newProduct = new Product { Name = "Monitor Samsung 21 pulg.", Price = 0 };

            // Act - When
            Product createdProduct = controller.Create(newProduct);

            // Assert - Then
            Assert.NotNull(createdProduct);
            Assert.Equal(newProduct.Name + " / Price Not Available", createdProduct.Name);
            Assert.Equal(0.0, createdProduct.Price);
            Assert.Equal(-1, createdProduct.Id);
        }
    }
}
