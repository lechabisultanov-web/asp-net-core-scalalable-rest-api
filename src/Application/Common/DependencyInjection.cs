using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ScalableRestApi.Application.Commands.Orders;
using ScalableRestApi.Application.Queries.Orders;
using ScalableRestApi.Application.Common.Behaviors;

namespace ScalableRestApi.Application.Common;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<CreateOrderCommandHandler>();
        services.AddScoped<GetOrderByIdQueryHandler>();

        services.AddValidatorsFromAssemblyContaining<CreateOrderCommandHandler>();
        services.AddAutoMapper(cfg => { }, typeof(CreateOrderCommandHandler).Assembly);
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<CreateOrderCommandHandler>();
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
            cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });

        return services;
    }
}