using API.Context;
using API.Models;
using API.Services;
using API.Services.Interfaces;
using API.Tests.Extensions;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace API.Tests.Repository
{
    public class ProductRepositoryTests
    {
        [Fact]
        public void GetProductList()
        {
            //Arrange
            var products = new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Name = "Catnip",
                    Price = 10
                },
                new Product()
                {
                    Id = 2,
                    Name = "Toilet Paper",
                    Price = 7
                },
                new Product()
                {
                    Id = 3,
                    Name = "Meat",
                    Price = 20
                },
                new Product()
                {
                    Id = 4,
                    Name = "Water",
                    Price = 5
                },
                new Product()
                {
                    Id = 5,
                    Name = "Gas Bottle",
                    Price = 28
                }
            }.AsQueryable();

            var mockedProducts = products.CreateMockDbSet();

            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(x => x.Products).Returns(mockedProducts.Object);

            var productRepository = new ProductRepository(mockContext.Object);

            //Act
            var productList = productRepository.ListProducts();

            //Assert
            Assert.Equal(products, productList);
            Mock.VerifyAll();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetProductById(int expected) 
        {
            //Arrange
            var products = new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Name = "Catnip",
                    Price = 10
                },
                new Product()
                {
                    Id = 2,
                    Name = "Toilet Paper",
                    Price = 7
                },
                new Product()
                {
                    Id = 3,
                    Name = "Meat",
                    Price = 20
                },
                new Product()
                {
                    Id = 4,
                    Name = "Water",
                    Price = 5
                },
                new Product()
                {
                    Id = 5,
                    Name = "Gas Bottle",
                    Price = 28
                }
            }.AsQueryable();

            var mockedProducts = products.CreateMockDbSet();

            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(x => x.Products).Returns(mockedProducts.Object);
            mockContext.Setup(x => x.Products.Find()).Returns(mockedProducts.Object.Find());

            var productRepository = new ProductRepository(mockContext.Object);

            //Act
            var actual = productRepository.GetProduct(expected);

            //Arrange
            Assert.Equal(expected, actual.Id);
            Mock.VerifyAll();
        }
    }
}
