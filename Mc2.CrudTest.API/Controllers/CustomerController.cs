using Mc2.CrudTest.Application.Commands;
using Mc2.CrudTest.Application.DTOs;
using Mc2.CrudTest.Application.Queries;
using Mc2.CrudTest.Shared.Abstraction.Commands;
using Mc2.CrudTest.Shared.Abstraction.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.API.Controllers;

public class CustomerController : BaseController
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public CustomerController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CustomerDto>> Get([FromRoute] GetCustomerQuery query)
    {
        var result = await _queryDispatcher.QueryAsync(query);
        return OkOrNotFound(result);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> Get()
    {
        var result = await _queryDispatcher.QueryAsync(new GetAllCustomersQuery());
        return OkOrNotFound(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateCustomerCommand command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return CreatedAtAction(nameof(Get), new { id = command.id }, null);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateCustomerCommand command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromBody] DeleteCustomerCommand command)
    {
        await _commandDispatcher.DispatchAsync(command);
        return Ok();
    }
}