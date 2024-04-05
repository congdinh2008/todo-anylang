using MediatR;
using Microsoft.EntityFrameworkCore;

namespace TodoMediatorAPI;

public class CategoryDeleteCommandHandler : HandlerBase, IRequestHandler<CategoryDeleteCommand, bool>
{
    public CategoryDeleteCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<bool> Handle(CategoryDeleteCommand request, CancellationToken cancellationToken)
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

        UnitOfWork.CategoryRepository.Delete(entity);

        return await UnitOfWork.SaveChangesAsync() > 0;
    }
}
