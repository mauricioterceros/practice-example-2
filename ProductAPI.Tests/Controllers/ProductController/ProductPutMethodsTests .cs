using Xunit;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Controllers;
using ProductAPI.Models;
using ProductAPI.Tests.Utils;

namespace ProductAPI.Controllers.UnitTests
{
    public class ProductPutMethodsTests
    {
        // Unit Test
        [Fact]
        public void UpdateProduct_ExistingId_ReturnsUpdatedProduct()
        {
            // Arrange - Given
            ProductController controller = ProductUtils.GetTestProductControllerStub();
            int productId = 1;
            Product updatedProduct = new Product { Id = productId, Name = "Macbook PRO", Price = 1500.0 };

            // Act - When
            Product result = controller.Update(productId, updatedProduct);

            // Assert - Then
            Assert.NotNull(result);
            Assert.Equal(updatedProduct.Name, result.Name);
            Assert.Equal(updatedProduct.Price, result.Price);
            Assert.Equal(productId, result.Id);
        }
    }
}
