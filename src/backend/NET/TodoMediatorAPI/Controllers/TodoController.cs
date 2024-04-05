using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TodoMediatorAPI;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public TodoController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("search")]
    [ProducesResponseType(typeof(PaginatedResult<TodoViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> SearchAsync([FromQuery] TodoSearchQuery filter)
    {
        var result = await _mediator.Send(filter);
        
        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<TodoViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync()
    {
        var query = new TodoGetAllQuery();
        
        var result = await _mediator.Send(query);
        
        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(TodoViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var query = new TodoGetByIdQuery { Id = id };
        var result = await _mediator.Send(query);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateAsync(TodoCreateCommand command)
    {
        if (command == null)
        {
            return BadRequest("Unable to parse body, please ensure the format is correct.");
        }

        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateAsync(TodoUpdateCommand command)
    {
        if (command == null)
        {
            return BadRequest("Unable to parse body, please ensure the format is correct.");
        }

        var result = await _mediator.Send(command);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var command = new TodoDeleteCommand { Id = id };
        var result = await _mediator.Send(command);

        if (!result)
        {
            return NotFound();
        }

        return Ok(result);
    }
}
