using AutoMapper;
using Moq;
using ScalableRestApi.Application.DTOs;
using ScalableRestApi.Application.Interfaces;
using ScalableRestApi.Application.Queries.Orders;
using ScalableRestApi.Domain.Entities;

namespace ScalableRestApi.UnitTests.Commands;

public class GetOrderByIdQueryHandlerTests
{
    private readonly Mock<IOrderRepository> _orderRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;

    public GetOrderByIdQueryHandlerTests()
    {
        _orderRepositoryMock = new Mock<IOrderRepository>();
        _mapperMock = new Mock<IMapper>();
    }

    [Fact]
    public async Task Handle_Should_Return_OrderDto_When_Order_Exists()
    {
        var orderId = Guid.NewGuid();
        var order = new Order("Alice");
        var expectedDto = new OrderDto
        {
            Id = orderId,
            CustomerName = "Alice",
            CreatedAt = DateTime.UtcNow
        };

        typeof(Order)
            .GetProperty(nameof(Order.Id))!
            .SetValue(order, orderId);

        _orderRepositoryMock
            .Setup(x => x.GetByIdAsync(orderId))
            .ReturnsAsync(order);

        _mapperMock
            .Setup(x => x.Map<OrderDto>(order))
            .Returns(expectedDto);

        var handler = new GetOrderByIdQueryHandler(
            _orderRepositoryMock.Object,
            _mapperMock.Object);

        var query = new GetOrderByIdQuery
        {
            Id = orderId
        };

        var result = await handler.Handle(query, CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(orderId, result!.Id);
        Assert.Equal("Alice", result.CustomerName);

        _orderRepositoryMock.Verify(x => x.GetByIdAsync(orderId), Times.Once);
        _mapperMock.Verify(x => x.Map<OrderDto>(order), Times.Once);
    }

    [Fact]
    public async Task Handle_Should_Return_Null_When_Order_Does_Not_Exist()
    {
        var orderId = Guid.NewGuid();

        _orderRepositoryMock
            .Setup(x => x.GetByIdAsync(orderId))
            .ReturnsAsync((Order)null!);

        var handler = new GetOrderByIdQueryHandler(
            _orderRepositoryMock.Object,
            _mapperMock.Object);

        var query = new GetOrderByIdQuery
        {
            Id = orderId
        };

        var result = await handler.Handle(query, CancellationToken.None);

        Assert.Null(result);

        _orderRepositoryMock.Verify(x => x.GetByIdAsync(orderId), Times.Once);
        _mapperMock.Verify(x => x.Map<OrderDto>(It.IsAny<Order>()), Times.Never);
    }
}