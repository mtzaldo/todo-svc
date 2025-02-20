using FluentResults;

namespace Todo.Broker.Features.Todo.RemoveTodo;

public class RemoveTodoUseCase: IRemoveTodoUseCase
{
    private readonly IRemoveTodoCommands cmd;

    public RemoveTodoUseCase(IRemoveTodoCommands cmd)
    {
        this.cmd = cmd;
    }

    public async Task<Result> DeleteTodo(int todoId, string username)
    {
        return await this.cmd.DeleteTodo(todoId, username);
    }
}

public interface IRemoveTodoUseCase
{
    Task<Result> DeleteTodo(int todoId, string username);
}