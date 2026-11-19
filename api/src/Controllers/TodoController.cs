

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TodoController : ControllerBase
{
    private readonly ILogger<TodoController> logger;
    private readonly ITodoService _todoService;

    public TodoController(ILogger<TodoController> logger, ITodoService todoService)
    {
        this.logger = logger;
        this._todoService = todoService;
    }

    [HttpPost("create-todolist")]
    public async Task<IActionResult> Post(
            [FromBody] CreateTodoDto todo)
    {
        logger.LogInformation("Executing POST method inside a TodoController at {0}", DateTime.Now);
        var result = await _todoService.CreateTodoAsync(todo);
        return result.IsSuccess ? Created() : BadRequest(result.Error);
    }

}