using FluentValidation;
using ScalableRestApi.Application.Commands.Orders;

namespace ScalableRestApi.Application.Validators;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{

    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.CustomerName)
        .NotEmpty()
        .WithMessage("Customer name is required.")
        .MaximumLength(30)
        .WithMessage("Customer name cant exeed 30 chars.");
    }
}