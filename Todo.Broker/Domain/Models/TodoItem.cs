namespace Todo.Broker.Domain.Models;
public record TodoItem
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public bool IsCompleted { get; set; }
}