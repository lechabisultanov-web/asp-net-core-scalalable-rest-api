using AutoMapper;
using FluentValidation;
using ScalableRestApi.Application.Interfaces;
using ScalableRestApi.Domain.Entities;
using ScalableRestApi.Application.DTOs;
namespace ScalableRestApi.Application.Services;

public class OrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IValidator<CreateOrderRequest> _createOrderRequestValidator;
    // “Give me a validator for CreateOrderRequest”
    private readonly IMapper _mapper;
    public OrderService(IOrderRepository orderRepository,
                        IValidator<CreateOrderRequest> createOrderRequestValidator,
                        IMapper mapper)
    {
        _orderRepository = orderRepository;
        _createOrderRequestValidator = createOrderRequestValidator;
        _mapper = mapper;
    }
    public async Task<OrderDto> CreateOrderAsync(CreateOrderRequest request)
    {
        await _createOrderRequestValidator.ValidateAndThrowAsync(request);
        var order = new Order(request.CustomerName);
        await _orderRepository.SaveAsync(order);

        /*         return new OrderDto
                {
                    Id = order.Id,
                    CustomerName = order.CustomerName,
                    CreatedAt = order.CreatedAt
                }; */
        // here we use now AutoMapper
        return _mapper.Map<OrderDto>(order);

    }
    public async Task<OrderDto?> GetOrderByIdAsync(Guid id)
    {
        var order = await _orderRepository.GetByIdAsync(id);
        if (order == null)
            return null;
        /*         return new OrderDto
                {
                    Id = order.Id,
                    CustomerName = order.CustomerName,
                    CreatedAt = order.CreatedAt
                }; */
        // here we use now AutoMapper
        return _mapper.Map<OrderDto>(order);
    }

}