using Todo.Broker.Domain.Entities;
using Todo.Broker.Domain.Models;

namespace Todo.Broker.Features.Todo.GetTodos;

public class GetTodosQueries : IGetTodosQueries
{
    private readonly DataContext db;

    public GetTodosQueries(DataContext db)
    {
        this.db = db;
    }
    public IEnumerable<TodoItem> GetTodos()
    {
        return this.db.Todos.Select(
            t => new TodoItem(t.Id, t.Title, t.Completed)
        );
    }
}

public interface IGetTodosQueries
{
    IEnumerable<TodoItem> GetTodos();
}