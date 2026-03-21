
using MediatR;
using ScalableRestApi.Application.DTOs;

namespace ScalableRestApi.Application.Commands.Orders;

public class CreateOrderCommand : IRequest<OrderDto>
{
    public string CustomerName { get; set; } = string.Empty;
}