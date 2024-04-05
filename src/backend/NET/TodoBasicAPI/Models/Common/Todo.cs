using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoBasicAPI;

[Table("Todos", Schema = "common")]
public class Todo: EntityBase
{
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string? Name { get; set; }

    [Required]
    [DefaultValue(false)]
    public bool IsComplete { get; set; }

    public int CategoryId { get; set; }

    public Category? Category { get; set; }
}