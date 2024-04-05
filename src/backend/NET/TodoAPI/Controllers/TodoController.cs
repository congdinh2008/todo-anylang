using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace TodoAPI;

[ApiController]
[Route("api/[controller]")]
public class TodoController: ControllerBase
{
    private readonly ITodoService _todoService;
    private readonly IMapper _mapper;

    public TodoController(ITodoService todoService, IMapper mapper)
    {
        _todoService = todoService;
        _mapper = mapper;
    }

    [HttpGet("search")]
    [ProducesResponseType(typeof(PaginatedResult<Todo>), 200)]
    public async Task<ActionResult<PaginatedResult<Todo>>> Search([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10)
    {
        var result = await _todoService.GetAsync(pageIndex: pageIndex, pageSize: pageSize);
        return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Todo>), 200)]
    public async Task<ActionResult<IEnumerable<Todo>>> GetAll()
    {
        var todos = await _todoService.GetAllAsync();
        return Ok(todos);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Todo), 200)]
    public async Task<ActionResult<Todo>> GetById(Guid id)
    {
        var todo = await _todoService.GetByIdAsync(id);
        if (todo == null)
        {
            return NotFound("Todo not found.");
        }
        return Ok(todo);
    }

    [HttpPost]
    [ProducesResponseType(typeof(bool), 201)]
    public async Task<ActionResult<bool>> Post(TodoViewModel todoViewModel)
    {
        var todo = _mapper.Map<Todo>(todoViewModel);
        var isSuccess = await _todoService.AddAsync(todo) > 0;
        return Ok(isSuccess);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> Put(Guid id, TodoViewModel todoViewModel)
    {
        var todo = await _todoService.GetByIdAsync(id);
        if (todo == null)
        {
            return NotFound("Todo not found.");
        }
        _mapper.Map(todoViewModel, todo);
        var isSuccess = await _todoService.UpdateAsync(todo);
        return Ok(isSuccess);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var todo = await _todoService.GetByIdAsync(id);
        if (todo == null)
        {
            return NotFound("Todo not found.");
        }
        var isSuccess = await _todoService.DeleteAsync(todo);
        return Ok(isSuccess);
    }
}
