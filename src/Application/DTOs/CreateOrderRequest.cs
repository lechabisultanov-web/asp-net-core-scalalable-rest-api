namespace ScalableRestApi.Application.DTOs;

public class CreateOrderRequest
{
    public string CustomerName { get; set; } = string.Empty;
    public int Age { get; set; } = 0;
}