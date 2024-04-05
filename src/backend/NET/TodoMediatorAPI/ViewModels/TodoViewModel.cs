namespace TodoMediatorAPI;

public class TodoViewModel : ViewModelBase
{
    public required string Name { get; set; }

    public bool IsComplete { get; set; }
    
    public Guid CategoryId { get; set; }
}