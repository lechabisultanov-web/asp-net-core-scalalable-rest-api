using System.Net;
using System.Net.Http.Json;
using ScalableRestApi.Application.Commands.Orders;
using ScalableRestApi.Application.DTOs;

namespace ScalableRestApi.IntegrationTests;

public class OrdersEndpointsTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;

    public OrdersEndpointsTests(CustomWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Post_Orders_Should_Create_Order()
    {
        var command = new CreateOrderCommand
        {
            CustomerName = "Integration Alice"
        };

        var response = await _client.PostAsJsonAsync("/api/orders", command);

        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<OrderDto>();

        Assert.NotNull(result);
        Assert.Equal("Integration Alice", result!.CustomerName);
        Assert.NotEqual(Guid.Empty, result.Id);
    }

    [Fact]
    public async Task Post_Orders_Should_Return_BadRequest_When_CustomerName_Is_Empty()
    {
        var command = new CreateOrderCommand
        {
            CustomerName = string.Empty
        };

        var response = await _client.PostAsJsonAsync("/api/orders", command);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
}