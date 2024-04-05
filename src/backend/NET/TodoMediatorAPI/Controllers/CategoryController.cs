using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TodoMediatorAPI;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CategoryController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("search")]
    [ProducesResponseType(typeof(PaginatedResult<CategoryViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> SearchAsync([FromQuery] CategorySearchQuery filter)
    {
        var result = await _mediator.Send(filter);
        
        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CategoryViewModel>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync(CategoryGetAllQuery query)
    {
        var result = await _mediator.Send(query);
        
        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(CategoryViewModel), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var query = new CategoryGetByIdQuery { Id = id };
        var result = await _mediator.Send(query);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateAsync(CategoryCreateCommand command)
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
    public async Task<IActionResult> UpdateAsync(CategoryUpdateCommand command)
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
        var command = new CategoryDeleteCommand { Id = id };
        var result = await _mediator.Send(command);

        if (!result)
        {
            return NotFound();
        }
        
        return Ok(result);
    }
}
