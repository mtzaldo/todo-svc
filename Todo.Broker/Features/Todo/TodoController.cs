using Microsoft.AspNetCore.Mvc;
using Todo.Broker.Features.Todo.AddTodo;
using Todo.Broker.Features.Todo.GetTodos;

namespace Todo.Broker.Features.Todo;

[Route("[controller]")]
[ApiController]
public class TodoController : ControllerBase
{
    [HttpPost]
    public IActionResult Post([FromServices]IAddTodoUseCase useCase)
    {
        return Ok(useCase.AddTodo("add a todo").ValueOrDefault);
    }

    [HttpGet]
    public IActionResult Get([FromServices]IGetTodosUseCase useCase)
    {
        return Ok(useCase.GetTodos());
    }
}