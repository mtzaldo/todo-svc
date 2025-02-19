using FluentResults;

namespace Todo.Broker.Features.Todo.AddTodo;

public class AddTodoUseCase : IAddTodoUseCase
{
    private readonly IAddTodoCommands commands;

    public AddTodoUseCase(IAddTodoCommands commands)
    {
        this.commands = commands;
    }
    public async Task<Result<int>> AddTodo(string username, string title, bool completed)
    {
        return await this.commands.SaveTodo(username, title, completed);
    }
}

public interface IAddTodoUseCase
{
    Task<Result<int>> AddTodo(string username, string title, bool completed);
}