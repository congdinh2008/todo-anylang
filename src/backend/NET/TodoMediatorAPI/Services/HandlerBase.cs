namespace TodoMediatorAPI;

public abstract class HandlerBase
{
    protected readonly IUnitOfWork UnitOfWork;

    protected HandlerBase(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }
}