using AutoMapper;
using FluentValidation;
using MediatR;

using ScalableRestApi.Application.DTOs;
using ScalableRestApi.Application.Interfaces;
using ScalableRestApi.Domain.Entities;

namespace ScalableRestApi.Application.Commands.Orders;
//IRequestHandler<TRequest, TResponse> is MediatR's interface that wires the command to
// its handler automatically.
public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderDto>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public CreateOrderCommandHandler(
        IOrderRepository orderRepository,
        IMapper mapper
    )
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }
    public async Task<OrderDto> Handle(CreateOrderCommand command,
        CancellationToken cancellationToken)
    {
        var order = new Order(command.CustomerName);
        await _orderRepository.SaveAsync(order);
        return _mapper.Map<OrderDto>(order);
    }
}