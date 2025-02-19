
using System.ComponentModel.DataAnnotations.Schema;

namespace Todo.Broker.Domain.Entities;

[Table("Todo")]
public class TodoEntity
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public bool Completed { get; set; }
    [ForeignKey("UserId")]
    public required UserEntity User { get; set; }
}