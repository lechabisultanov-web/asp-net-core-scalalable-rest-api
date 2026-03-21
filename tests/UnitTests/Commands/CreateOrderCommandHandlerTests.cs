using AutoMapper;
using Moq;
using ScalableRestApi.Application.Commands.Orders;
using ScalableRestApi.Application.DTOs;
using ScalableRestApi.Application.Interfaces;
using ScalableRestApi.Domain.Entities;

namespace ScalableRestApi.UnitTests.Commands;

public class CreateOrderCommandHandlerTests
{
    private readonly Mock<IOrderRepository> _orderRepositoryMock;
    private readonly Mock<IMapper> _mapperMock;

    public CreateOrderCommandHandlerTests()
    {
        _orderRepositoryMock = new Mock<IOrderRepository>();
        _mapperMock = new Mock<IMapper>();
    }

    [Fact]
    public async Task Handle_Should_Create_Order_And_Return_OrderDto()
    {
        var expectedDto = new OrderDto
        {
            Id = Guid.NewGuid(),
            CustomerName = "Alice",
            CreatedAt = DateTime.UtcNow
        };

        _mapperMock
            .Setup(x => x.Map<OrderDto>(It.IsAny<Order>()))
            .Returns(expectedDto);

        var handler = new CreateOrderCommandHandler(
            _orderRepositoryMock.Object,
            _mapperMock.Object);

        var command = new CreateOrderCommand
        {
            CustomerName = "Alice"
        };

        var result = await handler.Handle(command, CancellationToken.None);

        Assert.NotNull(result);
        Assert.IsType<OrderDto>(result);
        Assert.Equal("Alice", result.CustomerName);

        _orderRepositoryMock.Verify(
            x => x.SaveAsync(It.IsAny<Order>()),
            Times.Once);

        _mapperMock.Verify(
            x => x.Map<OrderDto>(It.IsAny<Order>()),
            Times.Once);
    }
}