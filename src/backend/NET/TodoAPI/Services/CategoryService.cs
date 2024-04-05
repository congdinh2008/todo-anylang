namespace TodoAPI;

public class CategoryService : ServiceBase<Category>, ICategoryService
{
    public CategoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}
