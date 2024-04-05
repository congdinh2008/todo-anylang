namespace TodoMediatorAPI;

public class TodoService : ServiceBase<Todo>, ITodoService
{
    public TodoService(IUnitOfWork unitOfWork) : base(unitOfWork)
    {
    }
}