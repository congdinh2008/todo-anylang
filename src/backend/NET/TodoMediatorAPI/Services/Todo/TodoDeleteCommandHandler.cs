using MediatR;
using Microsoft.EntityFrameworkCore;

namespace TodoMediatorAPI;

public class TodoDeleteCommandHandler : HandlerBase, IRequestHandler<TodoDeleteCommand, bool>
{
    public TodoDeleteCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<bool> Handle(TodoDeleteCommand request, CancellationToken cancellationToken)
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

        UnitOfWork.TodoRepository.Delete(entity);

        return await UnitOfWork.SaveChangesAsync() > 0;
    }
}
