using MediatR;
using Microsoft.EntityFrameworkCore;

namespace TodoMediatorAPI;

public class CategorySearchQueryHandler : HandlerBase, IRequestHandler<CategorySearchQuery, PaginatedResult<CategoryViewModel>>
{
    public CategorySearchQueryHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }

    public async Task<PaginatedResult<CategoryViewModel>> Handle(CategorySearchQuery request, CancellationToken cancellationToken)
    {
        var rawQuery = UnitOfWork.CategoryRepository.GetQuery();

        if (!string.IsNullOrWhiteSpace(request.Keyword))
        {
            rawQuery = rawQuery.Where(c => c.Name.Contains(request.Keyword));
        }

        var totalCount = await rawQuery.CountAsync();

        var query = rawQuery
            .Select(m => new CategoryViewModel
            {
                Id = m.Id,
                Name = m.Name,
            });

        if (!string.IsNullOrEmpty(request.OrderBy) && !string.IsNullOrEmpty(request.OrderDirection))
        {
            query = query.OrderByExtension(request.OrderBy, request.OrderDirection);
        }
        else
        {
            query = query.OrderBy(o => o.Name);
        }

        var results = await query.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToListAsync();

        return new PaginatedResult<CategoryViewModel>(
                request.PageNumber,
                request.PageSize,
                totalCount,
                results);
    }
}
