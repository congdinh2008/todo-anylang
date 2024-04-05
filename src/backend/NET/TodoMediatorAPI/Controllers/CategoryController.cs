using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace TodoMediatorAPI;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;

    public CategoryController(ICategoryService categoryService, IMapper mapper)
    {
        _categoryService = categoryService;
        _mapper = mapper;
    }

    [HttpGet("search")]
    [ProducesResponseType(typeof(PaginatedResult<Category>), 200)]
    public async Task<ActionResult<PaginatedResult<Category>>> Search([FromQuery] int pageIndex = 1, [FromQuery] int pageSize = 10)
    {
        var result = await _categoryService.GetAsync(pageIndex: pageIndex, pageSize: pageSize);
        return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Category>), 200)]
    public async Task<ActionResult<IEnumerable<Category>>> GetAll()
    {
        var categories = await _categoryService.GetAllAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Category), 200)]
    public async Task<ActionResult<Category>> GetById(Guid id)
    {
        var category = await _categoryService.GetByIdAsync(id);
        if (category == null)
        {
            return NotFound("Category not found.");
        }
        return Ok(category);
    }

    [HttpPost]
    [ProducesResponseType(typeof(bool), 201)]
    public async Task<ActionResult<bool>> Post(CategoryViewModel categoryViewModel)
    {
        var category = _mapper.Map<Category>(categoryViewModel);
        var isSuccess = await _categoryService.AddAsync(category) > 0;
        return Ok(isSuccess);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> Put(Guid id, CategoryViewModel categoryViewModel)
    {
        var category = await _categoryService.GetByIdAsync(id);
        if (category == null)
        {
            return NotFound("Category not found.");
        }

        _mapper.Map(categoryViewModel, category);
        var isSuccess = await _categoryService.UpdateAsync(category);

        return Ok(isSuccess);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(bool), 200)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var category = await _categoryService.GetByIdAsync(id);
        if (category == null)
        {
            return NotFound("Category not found.");
        }

        var isSuccess = await _categoryService.DeleteAsync(category);

        return Ok(isSuccess);
    }
}
