namespace TodoAPI;

public class TodoViewModel : ViewModelBase
{
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
    public int CategoryId { get; set; }
}