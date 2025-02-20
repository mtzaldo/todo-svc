using FluentResults;
using Todo.Broker.Domain.Models;

namespace Todo.Broker.Features.Todo.GetTodos;

public class GetTodosUserCase : IGetTodosUseCase
{
    public GetTodosUserCase(IGetTodosQueries queries)
    {
        this.queries = queries;
    }
    
    private readonly IGetTodosQueries queries;

    public async Task<Result<IEnumerable<TodoItem>>> GetTodos()
    {
        return await queries.GetTodos();
    }
}

public interface IGetTodosUseCase
{
    Task<Result<IEnumerable<TodoItem>>> GetTodos();
}