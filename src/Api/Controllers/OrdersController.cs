using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScalableRestApi.Application.Commands.Orders;
using ScalableRestApi.Application.Queries.Orders;

[ApiController]
[Route("api/[controller]")]

public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;
    public OrdersController(IMediator mediator)
    {
        _mediator = mediator;

    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateOrderCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetOrderByIdQuery
        {
            Id = id
        };
        var result = await _mediator.Send(query);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

}