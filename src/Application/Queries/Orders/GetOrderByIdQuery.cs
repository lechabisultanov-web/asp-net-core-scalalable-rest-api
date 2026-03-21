
using MediatR;
using ScalableRestApi.Application.DTOs;
namespace ScalableRestApi.Application.Queries.Orders;

public class GetOrderByIdQuery : IRequest<OrderDto?>
{
    public Guid Id { get; set; }
}