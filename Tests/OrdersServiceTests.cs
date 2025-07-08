using EcommerceAPI.Entities;
using EcommerceAPI.Interfaces;
using EcommerceAPI.Services;
using Moq;
using Xunit;

namespace EcommerceAPI.Tests;

public class OrdersServiceTests
{
    [Fact]
    public void GetAllOrders_ShouldReturnListOfOrders()
    {
        var mockRepository = new Mock<IOrdersRepository>();
        mockRepository.Setup(repo => repo.GetAllOrders()).Returns(new List<Order>
        {
            new Order { OrderId = "1", CustomerId = "123", OrderDate = DateTime.Now },
            new Order { OrderId = "2", CustomerId = "456", OrderDate = DateTime.Now }
        });

        var service = new OrdersService(mockRepository.Object);

        var result = service.GetAllOrders();

        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Equal("1", result[0].OrderId);
    }
    [Fact]
    public void GetAllOrders_ShouldReturnEmptyList_WhenNoOrdersExist()
    {
        var mockRepository = new Mock<IOrdersRepository>();
        mockRepository.Setup(repo => repo.GetAllOrders()).Returns(new List<Order>());
        var service = new OrdersService(mockRepository.Object);
        var result = service.GetAllOrders();
        Assert.NotNull(result);
        Assert.Empty(result);
    }
    [Fact]
    public void GetOrderById_ShouldReturnOrder()
    {
        var mockRepository = new Mock<IOrdersRepository>();
        var order = new Order { OrderId = "1", CustomerId = "123", OrderDate = DateTime.Now };
        mockRepository.Setup(repo => repo.GetOrderById("1")).Returns(order);
        var service = new OrdersService(mockRepository.Object);
        var result = service.GetOrderById("1");
        Assert.NotNull(result);
        Assert.Equal("1", result.OrderId);
    }
}