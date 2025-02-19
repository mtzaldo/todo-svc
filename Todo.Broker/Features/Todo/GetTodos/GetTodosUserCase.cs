using Todo.Broker.Domain.Models;

namespace Todo.Broker.Features.Todo.GetTodos;

public class GetTodosUserCase : IGetTodosUseCase
{
    public GetTodosUserCase(IGetTodosQueries queries)
    {
        this.queries = queries;
    }
    private static IEnumerable<TodoItem> todoItems = new List<TodoItem>()
    {
        new TodoItem() { Id = 1, Title = "title #1", IsCompleted = true },
        new TodoItem() { Id = 2, Title = "title #2", IsCompleted = true },
        new TodoItem() { Id = 3, Title = "title #3", IsCompleted = true },
        new TodoItem() { Id = 4, Title = "title #4", IsCompleted = true },
        new TodoItem() { Id = 5, Title = "title #5", IsCompleted = true },
        new TodoItem() { Id = 6, Title = "title #6", IsCompleted = true },
        new TodoItem() { Id = 7, Title = "title #7", IsCompleted = true },
        new TodoItem() { Id = 8, Title = "title #8", IsCompleted = true },
        new TodoItem() { Id = 9, Title = "title #9", IsCompleted = true },
        new TodoItem() { Id = 10, Title = "title #10", IsCompleted = true }
    };
    private readonly IGetTodosQueries queries;

    public IEnumerable<TodoItem> GetTodos()
    {
        return todoItems;
    }
}

public interface IGetTodosUseCase
{
    IEnumerable<TodoItem> GetTodos();
}