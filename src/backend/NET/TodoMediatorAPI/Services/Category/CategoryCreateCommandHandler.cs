using MediatR;
using Microsoft.EntityFrameworkCore;

namespace TodoMediatorAPI;

public class CategoryCreateCommandHandler : HandlerBase, IRequestHandler<CategoryCreateCommand, bool>
{
    public CategoryCreateCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<bool> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new HttpException(StatusCodes.Status404NotFound, "Invalid input");
        }

        var isDuplicate = await UnitOfWork.CategoryRepository.GetQuery().AnyAsync(x => x.Name == request.Name);
        if (isDuplicate)
        {
            throw new ArgumentException(Constants.ErrorFromServer + "The Category Name already exists.");
        }

        var entity = new Category
        {
            Id = request.Id ?? Guid.NewGuid(),
            Name = request.Name
        };

        UnitOfWork.CategoryRepository.Add(entity);

        return await UnitOfWork.SaveChangesAsync() > 0;
    }
}
