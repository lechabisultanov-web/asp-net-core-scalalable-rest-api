using AutoMapper;
using MediatR;
using ScalableRestApi.Application.DTOs;
using ScalableRestApi.Application.Interfaces;

namespace ScalableRestApi.Application.Queries.Orders;

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderDto?>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetOrderByIdQueryHandler(
        IOrderRepository orderRepository,
        IMapper mapper
    )
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<OrderDto?> Handle(GetOrderByIdQuery query,
        CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(query.Id);
        if (order == null)
            return null;
        return _mapper.Map<OrderDto>(order);
    }
}