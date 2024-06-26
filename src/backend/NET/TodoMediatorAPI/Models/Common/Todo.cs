using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoMediatorAPI;

[Table("Todos", Schema = "common")]
public class Todo: EntityBase
{
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public required string Name { get; set; }

    [Required]
    [DefaultValue(false)]
    public bool IsCompleted { get; set; }

    public Guid CategoryId { get; set; }

    public Category? Category { get; set; }
}