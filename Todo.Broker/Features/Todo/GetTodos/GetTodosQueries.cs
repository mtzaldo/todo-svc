using FluentResults;
using Microsoft.EntityFrameworkCore;
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
    public async Task<Result<IEnumerable<TodoItem>>> GetTodos()
    {
        IEnumerable<TodoItem> todos = await this.db.Todos
            .Where(t => t.Enabled)
            .Select(
                t => new TodoItem(t.Id, t.Title, t.Completed)
            ).ToListAsync();

        return Result.Ok(todos);
    }
}

public interface IGetTodosQueries
{
    Task<Result<IEnumerable<TodoItem>>> GetTodos();
}