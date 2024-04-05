using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace TodoMediatorAPI;

public class TodoGetByIdQueryHandler : HandlerBase, IRequestHandler<TodoGetByIdQuery, TodoViewModel>
{
    private readonly IMapper _mapper;

    public TodoGetByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
    {
        _mapper = mapper;
    }

    public async Task<TodoViewModel> Handle(TodoGetByIdQuery request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new HttpException(StatusCodes.Status404NotFound, "Invalid input");
        }

        var entity = await UnitOfWork.TodoRepository.GetQuery().FirstOrDefaultAsync(x => x.Id == request.Id);
        if (entity == null)
        {
            throw new ArgumentException(Constants.ErrorFromServer + "The Todo does not exist.");
        }

        return _mapper.Map<TodoViewModel>(entity);
    }
}
