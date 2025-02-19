using FluentResults;

namespace Todo.Broker.Features.Todo.AddTodo;

public class AddTodoUseCase : IAddTodoUseCase
{
    private readonly IAddTodoCommands commands;

    public AddTodoUseCase(IAddTodoCommands commands)
    {
        this.commands = commands;
    }
    public Result<string> AddTodo(string description)
    {
        return Result.Ok("Added");
    }
}

public interface IAddTodoUseCase
{
    Result<string> AddTodo(string description);
}