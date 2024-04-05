namespace TodoAPI;

public class Category
{
    public int Id { get; set; }

    public string? Name { get; set; }
    
    public List<Todo>? Items { get; set; }
}
