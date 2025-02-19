using Todo.Broker.Domain.Models;

namespace Todo.Broker.Features.Todo.GetTodos;

public class GetTodosUserCase : IGetTodosUseCase
{
    public GetTodosUserCase(IGetTodosQueries queries)
    {
        this.queries = queries;
    }
    
    private readonly IGetTodosQueries queries;

    public IEnumerable<TodoItem> GetTodos()
    {
        return queries.GetTodos();
    }
}

public interface IGetTodosUseCase
{
    IEnumerable<TodoItem> GetTodos();
}