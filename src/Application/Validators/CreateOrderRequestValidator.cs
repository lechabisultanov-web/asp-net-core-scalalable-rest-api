using FluentValidation;
using ScalableRestApi.Application.DTOs;

namespace ScalableRestApi.Application.Validators;

public class CreateOrderRequestvalidator : AbstractValidator<CreateOrderRequest>
{
    public CreateOrderRequestvalidator()
    {
        // Customer Name
        RuleFor(x => x.CustomerName)
             .NotEmpty()
             .WithMessage("Customer name is required")
             .MaximumLength(30)
             .WithMessage("Customer name cannot be more thhan 30 chars");
        // Age
        RuleFor(x => x.Age)
             .GreaterThan(0).WithMessage("Age must be greater than 0")
             .LessThanOrEqualTo(120).WithMessage("Age must be realistic");
    }
}