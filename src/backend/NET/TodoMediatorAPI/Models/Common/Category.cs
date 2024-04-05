using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoMediatorAPI;

[Table("Categories", Schema = "common")]
public class Category: EntityBase
{
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public required string Name { get; set; }
    
    public List<Todo>? Items { get; set; }
}
