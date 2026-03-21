namespace ScalableRestApi.Domain.Entities;

public class Order
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public string CustomerName { get; set; } = string.Empty;
    private Order() //the private empty constructor is for EF Core
    {
    }

    public Order(string customerName)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        CustomerName = customerName;
    }
}