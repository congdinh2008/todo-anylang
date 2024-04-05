using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace TodoMediatorAPI;

public class CategoryGetByIdQueryHandler : HandlerBase, IRequestHandler<CategoryGetByIdQuery, CategoryViewModel>
{
    private readonly IMapper _mapper;

    public CategoryGetByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
    {
        _mapper = mapper;
    }

    public async Task<CategoryViewModel> Handle(CategoryGetByIdQuery request, CancellationToken cancellationToken)
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

        return _mapper.Map<CategoryViewModel>(entity);
    }
}
