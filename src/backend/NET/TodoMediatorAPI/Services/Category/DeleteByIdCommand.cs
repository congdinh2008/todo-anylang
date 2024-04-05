using MediatR;

namespace TodoMediatorAPI;

public class DeleteByIdCommand: IRequest<bool>
{
    public Guid Id { get; set; }
}