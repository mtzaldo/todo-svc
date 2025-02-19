namespace Todo.Broker.Features.Todo;

public class TodoRequest
{
    public required string Username { get; set; }
    public required string Title { get; set; }
    public bool Completed { get; set; }
}