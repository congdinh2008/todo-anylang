using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace TodoMediatorAPI;

public class TodoGetAllQueryHandler : HandlerBase, IRequestHandler<TodoGetAllQuery, IEnumerable<TodoViewModel>>
{
    private readonly IMapper _mapper;

    public TodoGetAllQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
    {
        _mapper = mapper;
    }

    public async Task<IEnumerable<TodoViewModel>> Handle(TodoGetAllQuery request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new HttpException(StatusCodes.Status404NotFound, "Invalid input");
        }

        var query = await UnitOfWork.TodoRepository.GetQuery().OrderBy(x => x.Name).ToListAsync();

        return _mapper.Map<IEnumerable<TodoViewModel>>(query);
    }
}
