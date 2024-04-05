using MediatR;
using Microsoft.EntityFrameworkCore;

namespace TodoMediatorAPI;

public class TodoUpdateCommandHandler : HandlerBase, IRequestHandler<TodoUpdateCommand, bool>
{
    public TodoUpdateCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<bool> Handle(TodoUpdateCommand request, CancellationToken cancellationToken)
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

        entity.Name = request.Name;
        entity.IsCompleted = request.IsCompleted;
        entity.CategoryId = request.CategoryId;

        UnitOfWork.TodoRepository.Update(entity);

        return await UnitOfWork.SaveChangesAsync() > 0;
    }
}

