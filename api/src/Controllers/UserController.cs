


using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserDto request)
        {
            var response = await userService.CreateUserAsync(request);
            return Created(); // 201
        }
    }