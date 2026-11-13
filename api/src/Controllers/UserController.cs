


using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserDto request)
        {
            var response = await userService.CreateUserAsync(request);
            if(!response)
            {
                return BadRequest(response); // 400
            }
            var res= new { message = "User created successfully" , user = request,StatusCode=201 };
            return Ok(res); // 201
        }
    }