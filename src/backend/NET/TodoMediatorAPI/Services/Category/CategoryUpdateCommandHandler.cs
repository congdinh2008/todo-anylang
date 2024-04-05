using MediatR;
using Microsoft.EntityFrameworkCore;

namespace TodoMediatorAPI;

public class CategoryUpdateCommandHandler : HandlerBase, IRequestHandler<CategoryUpdateCommand, bool>
{
    public CategoryUpdateCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<bool> Handle(CategoryUpdateCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new HttpException(StatusCodes.Status404NotFound, "Invalid input");
        }

        var entity = await UnitOfWork.CategoryRepository.GetQuery().FirstOrDefaultAsync(x => x.Id == request.Id);

        if (entity == null)
        {
            throw new ArgumentException(Constants.ErrorFromServer + "The Category does not exist.");
        }

        entity.Name = request.Name;

        UnitOfWork.CategoryRepository.Update(entity);

        return await UnitOfWork.SaveChangesAsync() > 0;
    }
}

