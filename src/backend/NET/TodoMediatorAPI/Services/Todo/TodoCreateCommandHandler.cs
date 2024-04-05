using MediatR;
using Microsoft.EntityFrameworkCore;

namespace TodoMediatorAPI;

public class TodoCreateCommandHandler : HandlerBase, IRequestHandler<TodoCreateCommand, bool>
{
    public TodoCreateCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<bool> Handle(TodoCreateCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new HttpException(StatusCodes.Status404NotFound, "Invalid input");
        }

        var isDuplicate = await UnitOfWork.TodoRepository.GetQuery().AnyAsync(x => x.Name == request.Name);
        if (isDuplicate)
        {
            throw new ArgumentException(Constants.ErrorFromServer + "The Todo Name already exists.");
        }

        var entity = new Todo
        {
            Id = request.Id ?? Guid.NewGuid(),
            Name = request.Name,
            IsCompleted = request.IsCompleted,
            CategoryId = request.CategoryId
        };

        UnitOfWork.TodoRepository.Add(entity);

        return await UnitOfWork.SaveChangesAsync() > 0;
    }
}
