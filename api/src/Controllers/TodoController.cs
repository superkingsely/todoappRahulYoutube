

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TodoController : ControllerBase
{
    private readonly ILogger<TodoController> logger;

    public TodoController(ILogger<TodoController> logger)
    {
        this.logger = logger;
    }

    [HttpPost("TodoList")]
    public async Task<IActionResult> CreateTodoList([FromBody] CreateTodoDto requestDto)
    {
        // Implement the logic to create a todo list
        logger.LogInformation("Creating a new todo list with name: {Name}", requestDto.name);
        return Ok(new { message = "Todo list created successfully" });
    }

}