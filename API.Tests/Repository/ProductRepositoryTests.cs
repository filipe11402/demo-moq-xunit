using API.Services.Interfaces;
using API.Utils;
using Moq;
using Xunit;

namespace API.Tests.Repository
{
    public class ProductRepositoryTests
    {
        [Fact]
        public void GetProductList()
        {
            //Arrange
            var dbTestHelpers = new DbContextTestHelpers();
            var mockProductRepository = new Mock<IProductRepository>();
            var productList = dbTestHelpers.ProductListToTest;

            mockProductRepository.Setup(token => token.ListProducts())
                                 .Returns(productList);

            //Act
            var products = mockProductRepository.Object.ListProducts();
            dbTestHelpers.Dispose();

            //Assert
            Assert.Equal(products, productList);
        }
    }
}
