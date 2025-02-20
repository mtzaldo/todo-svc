using Microsoft.AspNetCore.Mvc;
using Todo.Broker.Domain.Boundaries;
using Todo.Broker.Features.Todo.AddTodo;
using Todo.Broker.Features.Todo.GetTodos;
using Todo.Broker.Features.Todo.RemoveTodo;

namespace Todo.Broker.Features.Todo;

[Route("[controller]")]
[ApiController]
public class TodoController : ControllerBase
{
    [HttpDelete("{todoId}")]
    public async Task<IActionResult> Delete(
        [FromServices]IRemoveTodoUseCase useCase,
        [FromRoute]int todoId,
        [FromQuery(Name = "u")]string username)
    {
        var result = await useCase.DeleteTodo(todoId, username);
        var response = result.ToApiResponse();

        return result.IsSuccess? Ok(response) : StatusCode(500, response);
    }

    [HttpPatch("{todoId}")]
    public IActionResult Patch([FromRoute]int todoId)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Post(
        [FromServices]IAddTodoUseCase useCase,
        [FromBody]TodoRequest todo,
        [FromQuery(Name = "u")]string username)
    {
        var result = await useCase.AddTodo(
                username, todo.Title, todo.Completed
            );
        
        var response = result.ToApiResponse();

        return result.IsSuccess? Ok(response) : NotFound(response);
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromServices]IGetTodosUseCase useCase)
    {
        var result = await useCase.GetTodos();
        var response = result.ToApiResponse();

        return result.IsSuccess? Ok(response) : StatusCode(500, response);
    }
}