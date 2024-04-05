using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace TodoMediatorAPI;

public class CategoryGetAllQueryHandler : HandlerBase, IRequestHandler<CategoryGetAllQuery, IEnumerable<CategoryViewModel>>
{
    private readonly IMapper _mapper;

    public CategoryGetAllQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
    {
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryViewModel>> Handle(CategoryGetAllQuery request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new HttpException(StatusCodes.Status404NotFound, "Invalid input");
        }

        var query = await UnitOfWork.CategoryRepository.GetQuery().OrderBy(x => x.Name).ToListAsync();

        return _mapper.Map<IEnumerable<CategoryViewModel>>(query);
    }
}
