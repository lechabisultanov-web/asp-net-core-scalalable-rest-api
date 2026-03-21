using ScalableRestApi.Domain.Entities;

namespace ScalableRestApi.Application.Interfaces;

public interface IOrderRepository
{
    Task<Order> GetByIdAsync(Guid id);
    Task SaveAsync(Order order);
}