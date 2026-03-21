using Microsoft.EntityFrameworkCore;
using ScalableRestApi.Application.Interfaces;
using ScalableRestApi.Domain.Entities;
using ScalableRestApi.Infrastructure.Persistence;

namespace ScalableRestApi.Infrastructure.Repositories;

public class MysqlOrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext _context;

    public MysqlOrderRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<Order> GetByIdAsync(Guid id)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
        return order!;
    }
    public async Task SaveAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();
    }
}