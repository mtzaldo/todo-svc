using Microsoft.AspNetCore.Mvc;

namespace Todo.Broker.Modules.AddTodo;

[Route("api/todo")]
[ApiController]
public class AddTodoController : Controller
{
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Added");
    }
}