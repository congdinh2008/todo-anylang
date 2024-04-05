using System.ComponentModel.DataAnnotations;

namespace TodoAPI;

public class Category: EntityBase
{
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string? Name { get; set; }
    
    public List<Todo>? Items { get; set; }
}
