using FluentResults;
using Microsoft.EntityFrameworkCore;
using Todo.Broker.Domain.Entities;

namespace Todo.Broker.Features.Todo.RemoveTodo;

public class RemoveTodoCommands : IRemoveTodoCommands
{
    private readonly DataContext db;

    public RemoveTodoCommands(DataContext db)
    {
        this.db = db;
    }

    public async Task<Result> DeleteTodo(int todoId, string username)
    {
        var rows = await this.db.Todos
            .Where(t => t.Id == todoId & t.User.Username == username)
            .ExecuteUpdateAsync(t => t.SetProperty(p => p.Enabled, false));

        return rows > 0? Result.Ok() : Result.Fail("Unable to delete the todo");
    }
}

public interface IRemoveTodoCommands
{
    Task<Result> DeleteTodo(int todoId, string username);
}