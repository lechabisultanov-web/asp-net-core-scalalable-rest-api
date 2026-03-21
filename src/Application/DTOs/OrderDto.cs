namespace ScalableRestApi.Application.DTOs;

public class OrderDto
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }

    public string CustomerName { get; set; } = string.Empty;
}