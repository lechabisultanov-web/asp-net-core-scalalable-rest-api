using FluentValidation.TestHelper;
using ScalableRestApi.Application.Commands.Orders;
using ScalableRestApi.Application.Validators;

namespace ScalableRestApi.UnitTests.Validators;

public class CreateOrderCommandValidatorTests
{
    private readonly CreateOrderCommandValidator _validator = new();

    [Fact]
    public void Should_Have_Error_When_CustomerName_Is_Empty()
    {
        var command = new CreateOrderCommand
        {
            CustomerName = string.Empty
        };

        var result = _validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(x => x.CustomerName);
    }

    [Fact]
    public void Should_Not_Have_Error_When_CustomerName_Is_Valid()
    {
        var command = new CreateOrderCommand
        {
            CustomerName = "Alice"
        };

        var result = _validator.TestValidate(command);

        result.ShouldNotHaveValidationErrorFor(x => x.CustomerName);
    }
}