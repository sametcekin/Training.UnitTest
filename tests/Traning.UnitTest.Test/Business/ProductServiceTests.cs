using Moq;
using System.Linq.Expressions;
using System.Text.Json;
using Training.UnitTest.Business;
using Training.UnitTest.Contracts;
using Training.UnitTest.Data.Entities;
using Training.UnitTest.Data.Repositories;

namespace Traning.UnitTest.Test.Business;

public class ProductServiceTests
{
    // GetAllAsync method returns a list of ProductDTOs with correct properties
    [Fact]
    public async Task GetAllAsync_ReturnsListOfProductDTOsWithCorrectProperties()
    {
        // Arrange
        var productEntityList = new List<Product>
        {
            new Product { Id = 1, SKU = "ABC123", Price = 10.99M },
            new Product { Id = 2, SKU = "DEF456", Price = 20.99M }
        };
        var productDTOList = new List<ProductDTO>
        {
            new ProductDTO { Id = 1, SKU = "ABC123", Price = 10.99M },
            new ProductDTO { Id = 2, SKU = "DEF456", Price = 20.99M }
        };
        var repositoryMock = new Mock<IProductRepository>();
        repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(productEntityList);
        var productService = new ProductService(repositoryMock.Object);

        // Act
        var result = await productService.GetAllAsync();

        // Assert
        Assert.True(result.IsSuccess);
        Assert.Equal("Products listed", result.Message);
        Assert.Equal(JsonSerializer.Serialize(productDTOList), JsonSerializer.Serialize(result.Data));
    }

    [Fact]
    public async Task CreateAsync_ReturnSucess()
    {
        // Arrange
        var productDTO = new ProductCreateDTO
        {
            SKU = "Product 1",
            Price = 10
        };

        var mockProductRepository = new Mock<IProductRepository>();

        mockProductRepository.Setup(x => x.FindAsync(It.IsAny<Expression<Func<Product, bool>>>()))
                     .ReturnsAsync((Product)null);

        mockProductRepository.Setup(x => x.AddAsync(It.IsAny<Product>()))
                             .ReturnsAsync(1);

        var service = new ProductService(mockProductRepository.Object);

        // Act
        var sut = await service.CreateAsync(productDTO);

        // Assert
        Assert.True(sut.IsSuccess);
        Assert.Equal(It.IsAny<int>(), sut.Data);
    }
}