using Microsoft.AspNetCore.Mvc;
using Todo.Broker.Domain.Boundaries;
using Todo.Broker.Features.Todo.AddTodo;
using Todo.Broker.Features.Todo.GetTodos;

namespace Todo.Broker.Features.Todo;

[Route("[controller]")]
[ApiController]
public class TodoController : ControllerBase
{
    [HttpPut]
    public IActionResult Put()
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Post(
        [FromServices]IAddTodoUseCase useCase,
        [FromBody]TodoRequest todo)
    {
        var result = await useCase.AddTodo(
                todo.Username, todo.Title, todo.Completed
            );
        
        var response = result.ToApiResponse();

        return result.IsSuccess? Ok(response) : NotFound(response);
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromServices]IGetTodosUseCase useCase)
    {
        var result = await useCase.GetTodos();
        var response = result.ToApiResponse();

        return result.IsSuccess? Ok(response) : NoContent();
    }
}