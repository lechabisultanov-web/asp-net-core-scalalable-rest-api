using AutoMapper;
using ScalableRestApi.Application.DTOs;
using ScalableRestApi.Domain.Entities;

namespace ScalableRestApi.Application.Mappings;

public class OrderMappingsProfile : Profile
{
    public OrderMappingsProfile()
    {
        // These are all mapping configurations 
        CreateMap<Order, OrderDto>();
        /* CreateMap<CreateOrderRequest, Order>();
           CreateMap<UpdateOrderRequest, Order>(); */
    }
}