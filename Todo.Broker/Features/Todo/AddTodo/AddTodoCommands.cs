using FluentResults;
using Todo.Broker.Domain.Entities;

namespace Todo.Broker.Features.Todo.AddTodo;

public class AddTodoCommands : IAddTodoCommands
{
    private readonly DataContext db;

    public AddTodoCommands(DataContext db)
    {
        this.db = db;
    }
    public async Task<Result<int>> SaveTodo(string username, string title, bool completed)
    {
        var user = db.Users.FirstOrDefault(u => u.Username == username);

        if (user is null) return Result.Fail("User not found.");

        var todo = new TodoEntity() {
            Title = title,
            Completed = completed,
            User = user
        };

        await db.Todos.AddAsync(todo);
        await db.SaveChangesAsync();

        return Result.Ok(todo.Id);
    }
}

public interface IAddTodoCommands
{
    Task<Result<int>> SaveTodo(string username, string title, bool completed);
}